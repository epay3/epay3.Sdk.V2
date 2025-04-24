using epay3.Web.Api.Sdk.V2.Client;
using epay3.Web.Api.Sdk.V2.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace epay3.Web.Api.Sdk.V2.Api
{
    public interface ITokensApi
    {
        bool TokensDelete(string id, string impersonationAccountKey = null);
        GetTokenResponseModel TokensGet(string id, string impersonationAccountKey = null);
        string TokensPost(PostTokenRequestModel postTokenRequestModel, string impersonationAccountKey = null);
    }

    public class TokensApi : ITokensApi
    {
        public TokensApi(string basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        public TokensApi(Configuration configuration = null)
        {
            this.Configuration = configuration ?? Configuration.Default;
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        public Configuration Configuration { get; set; }

        public bool TokensDelete(string id, string impersonationAccountKey = null)
        {
            var localVarPath = string.Format("/api/v1/Tokens/{0}", id);
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
                Method.Delete,
                localVarQueryParams,
                localVarPostBody,
                localVarHeaderParams,
                localVarFormParams,
                localVarFileParams,
                localVarPathParams,
                localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;
            if (localVarStatusCode == 200)
                return true;
            else if (localVarStatusCode >= 400)
            {
                var errorResponseModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorResponseModel>(localVarResponse.Content);
                throw new ApiException(localVarStatusCode, errorResponseModel != null ? errorResponseModel.Message : null);
            }
            else
                throw new ApiException(localVarStatusCode, localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
        }

        public GetTokenResponseModel TokensGet(string id, string impersonationAccountKey = null)
        {
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling TokensApi->TokensGet");

            var localVarPath = "/api/v1/tokens/{id}";
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
                throw new ApiException(localVarStatusCode, "Error calling TokensGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling TokensGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            var headerDict = localVarResponse.Headers.GroupBy(x => x.Name).ToDictionary(g => g.Key, g => string.Join(", ", g.Select(x => x.Value?.ToString())));

            var response = new ApiResponse<GetTokenResponseModel>(
                localVarStatusCode,
                headerDict,
                (GetTokenResponseModel)Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetTokenResponseModel)));

            return response.Data;
        }

        public string TokensPost(PostTokenRequestModel postTokenRequestModel, string impersonationAccountKey = null)
        {
            if (postTokenRequestModel == null)
                throw new ApiException(400, "Missing required parameter 'postTokenRequestModel' when calling TokensApi->TokensPost");

            var localVarPath = "/api/v1/Tokens";
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

            if (postTokenRequestModel.GetType() != typeof(byte[]))
                localVarPostBody = Configuration.ApiClient.Serialize(postTokenRequestModel);
            else
                localVarPostBody = postTokenRequestModel;

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
            if (localVarStatusCode >= 400)
            {
                var errorResponseModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorResponseModel>(localVarResponse.Content);
                throw new ApiException(localVarStatusCode, errorResponseModel != null ? errorResponseModel.Message : null);
            }
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return localVarResponse.Headers.First(x => x.Name == "Location").Value.ToString().Split('/').Last();
        }
    }
}
