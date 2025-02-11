using epay3.Web.Api.Sdk.V2.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace epay3.Web.Api.Sdk.V2.Client
{
    /// <summary>
    /// Represents a set of configuration settings
    /// </summary>
    public class Configuration
    {
        public Configuration(ApiClient apiClient = null,
                             Dictionary<string, string> defaultHeader = null,
                             string username = null,
                             string password = null,
                             string accessToken = null,
                             Dictionary<string, string> apiKey = null,
                             Dictionary<string, string> apiKeyPrefix = null,
                             string tempFolderPath = null,
                             string dateTimeFormat = null,
                             int timeout = 100000,
                             string userAgent = "Swagger-Codegen/1.0.0/csharp")
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            setApiClientUsingDefault(apiClient);
            Username = username;
            Password = password;
            AccessToken = accessToken;
            UserAgent = userAgent;
            if (defaultHeader != null)
                DefaultHeader = defaultHeader;
            if (apiKey != null)
                ApiKey = apiKey;
            if (apiKeyPrefix != null)
                ApiKeyPrefix = apiKeyPrefix;
            TempFolderPath = tempFolderPath;
            DateTimeFormat = dateTimeFormat;
            Timeout = timeout;
        }

        public Configuration(ApiClient apiClient)
        {
            setApiClientUsingDefault(apiClient);
        }

        public const string Version = "1.0.0";

        public static Configuration Default = new Configuration();

        private int _timeout = 100000;
        public int Timeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }

        public ApiClient ApiClient;

        public void setApiClientUsingDefault(ApiClient apiClient = null)
        {
            if (apiClient == null)
            {
                ApiClient = new ApiClient(this);
            }
            else
            {
                ApiClient = apiClient;
            }
        }


        private Dictionary<string, string> _defaultHeaderMap = new Dictionary<string, string>();
        public Dictionary<string, string> DefaultHeader
        {
            get { return _defaultHeaderMap; }
            set { _defaultHeaderMap = value; }
        }

        public void AddDefaultHeader(string key, string value)
        {
            _defaultHeaderMap.Add(key, value);
        }

        public string UserAgent { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AccessToken { get; set; }
        public Dictionary<string, string> ApiKey = new Dictionary<string, string>();
        public Dictionary<string, string> ApiKeyPrefix = new Dictionary<string, string>();

        public string GetApiKeyWithPrefix(string apiKeyIdentifier)
        {
            string apiKeyValue = "";
            ApiKey.TryGetValue(apiKeyIdentifier, out apiKeyValue);
            string apiKeyPrefix = "";
            if (ApiKeyPrefix.TryGetValue(apiKeyIdentifier, out apiKeyPrefix))
                return apiKeyPrefix + " " + apiKeyValue;
            else
                return apiKeyValue;
        }

        private string _tempFolderPath = Path.GetTempPath();
        public string TempFolderPath
        {
            get { return _tempFolderPath; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _tempFolderPath = value;
                    return;
                }
                if (!Directory.Exists(value))
                    Directory.CreateDirectory(value);
                _tempFolderPath = value.EndsWith(Path.DirectorySeparatorChar.ToString())
                    ? value
                    : value + Path.DirectorySeparatorChar;
            }
        }

        private const string ISO8601_DATETIME_FORMAT = "o";
        private string _dateTimeFormat = ISO8601_DATETIME_FORMAT;
        public string DateTimeFormat
        {
            get { return _dateTimeFormat; }
            set { _dateTimeFormat = string.IsNullOrEmpty(value) ? ISO8601_DATETIME_FORMAT : value; }
        }

        public static string ToDebugReport()
        {
            string report = "C# SDK (epay3.Web.Api.Sdk) Debug Report:\n";
            report += "    OS: " + Environment.OSVersion + "\n";
            report += "    .NET Framework Version: " + Assembly.GetExecutingAssembly()
                     .GetReferencedAssemblies().Where(x => x.Name == "System.Core").First().Version.ToString() + "\n";
            report += "    Version of the API: v2\n";
            report += "    SDK Package Version: 1.0.0\n";
            return report;
        }
    }
}
