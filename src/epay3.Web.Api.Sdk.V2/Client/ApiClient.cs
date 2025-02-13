using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace epay3.Web.Api.Sdk.V2.Client
{
    /// <summary>
    /// API client is mainly responsible for making the HTTP call to the API backend.
    /// </summary>
    public class ApiClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient" /> class
        /// with default configuration and base path (https://api-sandbox.epay3.com:443).
        /// </summary>
        public ApiClient()
        {
            Configuration = Configuration.Default;
            var options = new RestClientOptions("https://api-sandbox.epay3.com:443")
            {
                Timeout = TimeSpan.FromMilliseconds(Configuration.Timeout),
                UserAgent = Configuration.UserAgent
            };
            RestClient = new RestClient(options);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient" /> class
        /// with default base path (https://api-sandbox.epay3.com:443) and the provided configuration.
        /// </summary>
        /// <param name="config">An instance of Configuration.</param>
        public ApiClient(Configuration config = null)
        {
            Configuration = config ?? Configuration.Default;
            var options = new RestClientOptions("https://api-sandbox.epay3.com:443")
            {
                Timeout = TimeSpan.FromMilliseconds(Configuration.Timeout),
                UserAgent = Configuration.UserAgent
            };
            RestClient = new RestClient(options);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient" /> class
        /// with default configuration and the provided base path.
        /// </summary>
        /// <param name="basePath">The base path.</param>
        public ApiClient(string basePath = "https://api-sandbox.epay3.com:443")
        {
            if (string.IsNullOrEmpty(basePath))
                throw new ArgumentException("basePath cannot be empty");

            // Here we use the default configuration values.
            var options = new RestClientOptions(basePath)
            {
                Timeout = TimeSpan.FromMilliseconds(Configuration.Default.Timeout),
                UserAgent = Configuration.Default.UserAgent
            };
            RestClient = new RestClient(options);
            Configuration = Configuration.Default;
        }

        /// <summary>
        /// Gets or sets the Configuration.
        /// </summary>
        public Configuration Configuration { get; set; }

        /// <summary>
        /// Gets or sets the RestClient.
        /// </summary>
        public RestClient RestClient { get; set; }

        // Creates and sets up a RestRequest prior to a call.
        private RestRequest PrepareRequest(
            string path, Method method, Dictionary<string, string> queryParams, object postBody,
            Dictionary<string, string> headerParams, Dictionary<string, string> formParams,
            Dictionary<string, FileParameter> fileParams, Dictionary<string, string> pathParams,
            string contentType)
        {
            var request = new RestRequest(path, method);

            // Add path parameters (URL segments)
            foreach (var param in pathParams)
                request.AddParameter(param.Key, param.Value, ParameterType.UrlSegment);

            // Add header parameters
            foreach (var param in headerParams)
            {
                if (param.Value != null)
                {
                    request.AddHeader(param.Key, param.Value);
                }
            }

            // Add query parameters
            foreach (var param in queryParams)
                request.AddQueryParameter(param.Key, param.Value);

            // Add form parameters
            foreach (var param in formParams)
                request.AddParameter(param.Key, param.Value);

            // Add file parameters
            foreach (var param in fileParams)
            {
                request.AddFile(
                    name: param.Value.Name,
                    getFile: () => File.OpenRead(param.Value.FileName),
                    fileName: Path.GetFileName(param.Value.FileName),
                    contentType: param.Value.ContentType
                );
            }

            // Add the HTTP body (if provided)
            if (postBody != null)
            {
                if (postBody is string)
                {
                    request.AddParameter("application/json", postBody, ParameterType.RequestBody);
                }
                else if (postBody is byte[])
                {
                    request.AddParameter(contentType, postBody, ParameterType.RequestBody);
                }
                else
                {
                    // Serialize any other object as JSON
                    string json = JsonConvert.SerializeObject(postBody);
                    request.AddParameter("application/json", json, ParameterType.RequestBody);
                }
            }

            return request;
        }

        /// <summary>
        /// Makes the HTTP request (synchronously).
        /// </summary>
        public object CallApi(
            string path, Method method, Dictionary<string, string> queryParams, object postBody,
            Dictionary<string, string> headerParams, Dictionary<string, string> formParams,
            Dictionary<string, FileParameter> fileParams, Dictionary<string, string> pathParams,
            string contentType)
        {
            var request = PrepareRequest(path, method, queryParams, postBody, headerParams, formParams, fileParams, pathParams, contentType);

            // The timeout and user agent are already set via RestClientOptions,
            // so there's no need to set them here.
            var response = RestClient.Execute(request);
            return response;
        }

        /// <summary>
        /// Makes the asynchronous HTTP request.
        /// </summary>
        public async Task<object> CallApiAsync(
            string path, Method method, Dictionary<string, string> queryParams, object postBody,
            Dictionary<string, string> headerParams, Dictionary<string, string> formParams,
            Dictionary<string, FileParameter> fileParams, Dictionary<string, string> pathParams,
            string contentType)
        {
            var request = PrepareRequest(path, method, queryParams, postBody, headerParams, formParams, fileParams, pathParams, contentType);
            var response = await RestClient.ExecuteAsync(request);
            return response;
        }

        /// <summary>
        /// URL-encodes a string.
        /// </summary>
        public string EscapeString(string str)
        {
            return UrlEncode(str);
        }

        /// <summary>
        /// Creates a FileParameter from a stream.
        /// </summary>
        public FileParameter ParameterToFile(string name, Stream stream)
        {
            if (stream is FileStream fileStream)
                return FileParameter.Create(name, ReadAsBytes(stream), Path.GetFileName(fileStream.Name));
            else
                return FileParameter.Create(name, ReadAsBytes(stream), "no_file_name_provided");
        }

        /// <summary>
        /// Converts a parameter to its string representation.
        /// For DateTime types, it uses the configured date/time format.
        /// For lists, it joins the elements with commas.
        /// </summary>
        public string ParameterToString(object obj)
        {
            if (obj is DateTime dt)
                return dt.ToString(Configuration.DateTimeFormat);
            else if (obj is DateTimeOffset dto)
                return dto.ToString(Configuration.DateTimeFormat);
            else if (obj is IList list)
            {
                var sb = new StringBuilder();
                foreach (var param in list)
                {
                    if (sb.Length > 0)
                        sb.Append(",");
                    sb.Append(param);
                }
                return sb.ToString();
            }
            else
                return Convert.ToString(obj);
        }

        /// <summary>
        /// Deserializes the JSON response content into an object of the specified type.
        /// </summary>
        public object Deserialize(RestResponse response, Type type)
        {
            IList<Parameter> headers = new List<Parameter>(response.Headers);
            if (type == typeof(byte[]))
            {
                return response.RawBytes;
            }

            if (type == typeof(Stream))
            {
                if (headers != null)
                {
                    var filePath = string.IsNullOrEmpty(Configuration.TempFolderPath)
                        ? Path.GetTempPath()
                        : Configuration.TempFolderPath;
                    var regex = new Regex(@"Content-Disposition=.*filename=['""]?([^'""\s]+)['""]?$");
                    foreach (var header in headers)
                    {
                        var match = regex.Match(header.ToString());
                        if (match.Success)
                        {
                            string fileName = filePath + SanitizeFilename(match.Groups[1].Value.Replace("\"", "").Replace("'", ""));
                            File.WriteAllBytes(fileName, response.RawBytes);
                            return new FileStream(fileName, FileMode.Open);
                        }
                    }
                }
                return new MemoryStream(response.RawBytes);
            }

            if (type.Name.StartsWith("System.Nullable`1[[System.DateTime"))
            {
                return DateTime.Parse(response.Content, null, System.Globalization.DateTimeStyles.RoundtripKind);
            }

            if (type == typeof(string) || type.Name.StartsWith("System.Nullable"))
            {
                return ConvertType(response.Content, type);
            }

            try
            {
                return JsonConvert.DeserializeObject(response.Content, type);
            }
            catch (Exception e)
            {
                throw new ApiException(500, e.Message);
            }
        }

        /// <summary>
        /// Serializes an object into a JSON string.
        /// </summary>
        public string Serialize(object obj)
        {
            try
            {
                return obj != null ? JsonConvert.SerializeObject(obj) : null;
            }
            catch (Exception e)
            {
                throw new ApiException(500, e.Message);
            }
        }

        /// <summary>
        /// Selects the Content-Type header's value from the given array.
        /// </summary>
        public string SelectHeaderContentType(string[] contentTypes)
        {
            if (contentTypes.Length == 0)
                return null;
            if (contentTypes.Contains("application/json", StringComparer.OrdinalIgnoreCase))
                return "application/json";
            return contentTypes[0];
        }

        /// <summary>
        /// Selects the Accept header's value from the given array.
        /// </summary>
        public string SelectHeaderAccept(string[] accepts)
        {
            if (accepts.Length == 0)
                return null;
            if (accepts.Contains("application/json", StringComparer.OrdinalIgnoreCase))
                return "application/json";
            return string.Join(",", accepts);
        }

        /// <summary>
        /// Encodes a string in base64.
        /// </summary>
        public static string Base64Encode(string text)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
        }

        /// <summary>
        /// Dynamically casts an object to a specified type.
        /// </summary>
        public static dynamic ConvertType(dynamic source, Type dest)
        {
            return Convert.ChangeType(source, dest);
        }

        /// <summary>
        /// Reads the entire stream as a byte array.
        /// </summary>
        public static byte[] ReadAsBytes(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        /// <summary>
        /// URL-encodes a string.
        /// </summary>
        public static string UrlEncode(string input)
        {
            const int maxLength = 32766;
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            if (input.Length <= maxLength)
                return Uri.EscapeDataString(input);

            StringBuilder sb = new StringBuilder(input.Length * 2);
            int index = 0;
            while (index < input.Length)
            {
                int length = Math.Min(input.Length - index, maxLength);
                string subString = input.Substring(index, length);
                sb.Append(Uri.EscapeDataString(subString));
                index += subString.Length;
            }
            return sb.ToString();
        }

        /// <summary>
        /// Sanitizes a filename by removing its path.
        /// </summary>
        public static string SanitizeFilename(string filename)
        {
            Match match = Regex.Match(filename, @".*[/\\](.*)$");
            return match.Success ? match.Groups[1].Value : filename;
        }
    }
}
