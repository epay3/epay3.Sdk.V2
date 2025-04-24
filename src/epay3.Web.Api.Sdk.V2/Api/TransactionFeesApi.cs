using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using epay3.Web.Api.Sdk.V2.Client;
using epay3.Web.Api.Sdk.V2.Models;
using Newtonsoft.Json;

namespace epay3.Web.Api.Sdk.V2.Api
{
    
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ITransactionFeesApi
    {
        /// <summary>
        /// Calculates and returns transaction fees for a given subtotal amount based on the account.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="epay3.Web.Api.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="amount">Subtotal from which to calculate the transaction fees.</param>
        /// <param name="attributeValues">Attribute Values dictionary, serialized. (optional)</param>
        /// <param name="impersonationAccountKey"> (optional, default to )</param>
        /// <returns>GetTransactionFeesResponseModel</returns>
        GetTransactionFeesResponseModel TransactionFeesGet(decimal amount, Dictionary<string, string> attributeValues = null, string impersonationAccountKey = null);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class TransactionFeesApi : ITransactionFeesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionFeesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public TransactionFeesApi(String basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionFeesApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public TransactionFeesApi(Configuration configuration = null)
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
        public Configuration Configuration { get; set; }

        /// <summary>
        /// Calculates and returns transaction fees for a given subtotal amount based on the account. 
        /// </summary>
        /// <exception cref="epay3.Web.Api.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="amount">Subtotal from which to calculate the transaction fees.</param> 
        /// <param name="attributeValues">Attribute Values dictionary, serialized. (optional)</param> 
        /// <param name="impersonationAccountKey"> (optional, default to )</param> 
        /// <returns>ApiResponse of GetTransactionFeesResponseModel</returns>
        public GetTransactionFeesResponseModel TransactionFeesGet (decimal amount, Dictionary<string, string> attributeValues = null, string impersonationAccountKey = null)
        {
            
            var localVarPath = "/api/v1/transactionFees";
    
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

            if (amount != null) localVarQueryParams.Add("amount", Configuration.ApiClient.ParameterToString(amount)); // query parameter

            if (attributeValues != null)
            {
                foreach (var attributeValue in attributeValues)
                {
                    localVarQueryParams.Add(attributeValue.Key, attributeValue.Value); // query parameter
                }
            }
            
            if (impersonationAccountKey != null) localVarHeaderParams.Add("impersonationAccountKey", Configuration.ApiClient.ParameterToString(impersonationAccountKey)); // header parameter

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) Configuration.ApiClient.CallApi(localVarPath, 
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling TransactionFeesGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling TransactionFeesGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            var headerDict = localVarResponse.Headers.GroupBy(x => x.Name)
                .ToDictionary(g => g.Key, g => string.Join(", ", g.Select(x => x.Value?.ToString())));

            return new ApiResponse<GetTransactionFeesResponseModel>(
                localVarStatusCode,
                headerDict,
                (GetTransactionFeesResponseModel)Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetTransactionFeesResponseModel))
            ).Data;

        }
    }
}
