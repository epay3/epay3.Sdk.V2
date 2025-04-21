using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using epay3.Web.Api.Sdk.V2.Client;
using epay3.Web.Api.Sdk.V2.Models;

namespace epay3.Web.Api.Sdk.V2.Api
{
    public interface IBatchesApi
    {
        GetBatchesResponseModel BatchesGet (int? page = null, string impersonationAccountKey = null);
        GetTransactionsResponseModel GetBatchTransactions(long id, string impersonationAccountKey = null);
    }
  
    public class BatchesApi : IBatchesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BatchesApi(String basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchesApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public BatchesApi(Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = Configuration.Default; 
            else
                this.Configuration = configuration;

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.Options.BaseUrl.ToString();
        }
  
        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Configuration Configuration {get; set;}

        /// <summary>
        /// Gets a collection of Batches. 
        /// </summary>
        /// <exception cref="epay3.Web.Api.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="page"> (optional)</param> 
        /// <param name="impersonationAccountKey"> (optional, default to )</param> 
        /// <returns>ApiResponse of Object(void)</returns>
        public GetBatchesResponseModel BatchesGet(int? page = null, string impersonationAccountKey = null)
        {
            var localVarPath = "/api/v2/Batches";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json", "text/json", "application/xml", "text/xml"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            
            if (page != null) localVarQueryParams.Add("page", Configuration.ApiClient.ParameterToString(page)); // query parameter
            
            if (impersonationAccountKey != null) localVarHeaderParams.Add("impersonationAccountKey", Configuration.ApiClient.ParameterToString(impersonationAccountKey)); // header parameter
            
            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) Configuration.ApiClient.CallApi(localVarPath, 
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling BatchesGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling BatchesGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);


            var headersDict = localVarResponse.Headers.GroupBy(x => x.Name).ToDictionary(g => g.Key,
                g => string.Join(", ", g.Select(x => x.Value?.ToString() ?? string.Empty)));

            return new ApiResponse<GetBatchesResponseModel>(
                localVarStatusCode,
                headersDict,
                (GetBatchesResponseModel)Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetBatchesResponseModel))
            ).Data;
        }

        /// <summary>
        /// Gets all the transactions of a given Batch.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="id">Batch ID.</param>
        /// <param name="impersonationAccountKey">The key that allows impersonation of another account for which the batches were processed. Only specify a value if the account being impersonated is different from the account that is submitting this request.</param>
        /// <returns></returns>
        public GetTransactionsResponseModel GetBatchTransactions(long id, string impersonationAccountKey = null)
        {
            var localVarPath = "/api/v2/batches/{id}/transactions";

            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {

            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json", "text/json", "application/xml", "text/xml"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            localVarPathParams.Add("id", Configuration.ApiClient.ParameterToString(id)); // path parameter

            if (impersonationAccountKey != null) localVarHeaderParams.Add("impersonationAccountKey", Configuration.ApiClient.ParameterToString(impersonationAccountKey)); // header parameter

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException(localVarStatusCode, "Error calling GetBatchTransactions: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling GetBatchTransactions: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);


            var headersDict = localVarResponse.Headers.GroupBy(x => x.Name).ToDictionary(g => g.Key,
                g => string.Join(", ", g.Select(x => x.Value?.ToString() ?? string.Empty)));

            return new ApiResponse<GetTransactionsResponseModel>(
                localVarStatusCode,
                headersDict,
                (GetTransactionsResponseModel)Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetTransactionsResponseModel))
            ).Data;
        }
    }
}
