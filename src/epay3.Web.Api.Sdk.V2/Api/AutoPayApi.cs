using epay3.Web.Api.Sdk.V2.Client;
using epay3.Web.Api.Sdk.V2.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace epay3.Web.Api.Sdk.V2.Api
{
    public interface IAutoPayApi
    {
        GetAutoPayResponseModel AutoPayGet(long id, string impersonationAccountKey = null);
        long? AutoPayPost(PostAutoPayRequestModel postAutoPayRequestModel, string impersonationAccountKey = null);
        bool AutoPayCancel(long id, string impersonationAccountKey = null);
    }

    public class AutoPayApi : IAutoPayApi
    {
        public AutoPayApi(string basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        public AutoPayApi(Configuration configuration = null)
        {
            this.Configuration = configuration ?? Configuration.Default;
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        public string GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.Options.BaseUrl.ToString();
        }

        [Obsolete("SetBasePath is deprecated, please use 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(string basePath)
        {
        }

        public Configuration Configuration { get; set; }

        public bool AutoPayCancel(long id, string impersonationAccountKey = null)
        {
            if (id == 0)
                throw new ApiException(400, "Missing required parameter 'id' when calling AutoPayApi->AutoPayCancel");

            var localVarPath = string.Format("/api/v2/autoPay/{0}/cancel", id);
            var localVarPathParams = new Dictionary<string, string>
            {
                { "format", "json" }
            };
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            string[] localVarHttpContentTypes = new string[] { "application/json", "text/json", "application/xml", "text/xml", "application/x-www-form-urlencoded" };
            string localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);
            string[] localVarHttpHeaderAccepts = new string[] { "application/json", "text/json", "application/xml", "text/xml" };
            string localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (impersonationAccountKey != null)
                localVarHeaderParams.Add("impersonationAccountKey", Configuration.ApiClient.ParameterToString(impersonationAccountKey));

            RestResponse localVarResponse = (RestResponse)Configuration.ApiClient.CallApi(
                localVarPath,
                Method.Post,
                localVarQueryParams,
                localVarPostBody,
                localVarHeaderParams,
                localVarFormParams,
                localVarFileParams,
                localVarPathParams,
                localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;
            if (localVarStatusCode == 400)
            {
                var errorResponseModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorResponseModel>(localVarResponse.Content);
                throw new ApiException(localVarStatusCode, errorResponseModel?.Message);
            }
            else if (localVarStatusCode >= 400)
            {
                var errorResponseModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorResponseModel>(localVarResponse.Content);
                throw new ApiException(localVarStatusCode, errorResponseModel?.Message);
            }
            else if (localVarStatusCode == 0)
            {
                throw new ApiException(localVarStatusCode, localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
            }
            return true;
        }

        public GetAutoPayResponseModel AutoPayGet(long id, string impersonationAccountKey = null)
        {
            if (id == 0)
                throw new ApiException(400, "Missing required parameter 'id' when calling AutoPayApi->AutoPayGet");

            var localVarPath = "/api/v2/autoPay/{id}";
            var localVarPathParams = new Dictionary<string, string>
            {
                { "format", "json" },
                { "id", Configuration.ApiClient.ParameterToString(id) }
            };
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);
            string[] localVarHttpHeaderAccepts = new string[] { "application/json", "text/json", "application/xml", "text/xml" };
            string localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (impersonationAccountKey != null)
                localVarHeaderParams.Add("impersonationAccountKey", Configuration.ApiClient.ParameterToString(impersonationAccountKey));

            RestResponse localVarResponse = (RestResponse)Configuration.ApiClient.CallApi(
                localVarPath,
                Method.Get,
                localVarQueryParams,
                localVarPostBody,
                localVarHeaderParams,
                localVarFormParams,
                localVarFileParams,
                localVarPathParams,
                localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;
            if (localVarStatusCode >= 400)
                throw new ApiException(localVarStatusCode, "Error calling AutoPayGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling AutoPayGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            var headersDict = localVarResponse.Headers.GroupBy(x => x.Name).ToDictionary(g => g.Key,
                g => string.Join(", ", g.Select(x => x.Value?.ToString() ?? string.Empty)));

            var response = new ApiResponse<GetAutoPayResponseModel>(
                localVarStatusCode,
                headersDict,
                (GetAutoPayResponseModel)Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetAutoPayResponseModel)));

            return response.Data;
        }

        public long? AutoPayPost(PostAutoPayRequestModel postAutoPayRequestModel, string impersonationAccountKey = null)
        {
            if (postAutoPayRequestModel == null)
                throw new ApiException(400, "Missing required parameter 'postAutoPayRequestModel' when calling AutoPayApi->AutoPayPost");

            var localVarPath = "/api/v2/autoPay";
            var localVarPathParams = new Dictionary<string, string>
            {
                { "format", "json" }
            };
            var localVarQueryParams = new Dictionary<string, string>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            string[] localVarHttpContentTypes = new string[] { "application/json", "text/json", "application/xml", "text/xml", "application/x-www-form-urlencoded" };
            string localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);
            string[] localVarHttpHeaderAccepts = new string[] { "application/json", "text/json", "application/xml", "text/xml" };
            string localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (impersonationAccountKey != null)
                localVarHeaderParams.Add("impersonationAccountKey", Configuration.ApiClient.ParameterToString(impersonationAccountKey));

            if (postAutoPayRequestModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(postAutoPayRequestModel);
            }
            else
            {
                localVarPostBody = postAutoPayRequestModel;
            }

            RestResponse localVarResponse = (RestResponse)Configuration.ApiClient.CallApi(
                localVarPath,
                Method.Post,
                localVarQueryParams,
                localVarPostBody,
                localVarHeaderParams,
                localVarFormParams,
                localVarFileParams,
                localVarPathParams,
                localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;
            if (localVarStatusCode == 400)
            {
                var errorResponseModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorResponseModel>(localVarResponse.Content);
                throw new ApiException(localVarStatusCode, errorResponseModel != null ? errorResponseModel.Message : null);
            }
            else if (localVarStatusCode >= 400)
            {
                var errorResponseModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorResponseModel>(localVarResponse.Content);
                throw new ApiException(localVarStatusCode, errorResponseModel != null ? errorResponseModel.Message : null);
            }
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            var id = localVarResponse.Headers.First(x => x.Name == "Location").Value.ToString().Split('/').Last();
            return long.Parse(id);
        }
    }
}
