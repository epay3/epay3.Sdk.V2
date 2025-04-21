using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using epay3.Web.Api.Sdk.V2.Client;
using epay3.Web.Api.Sdk.V2.Models;

namespace epay3.Web.Api.Sdk.V2.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IManagedInvoicesApi
    {
        GetManagedInvoiceResponseModel ManagedInvoicesGet(string id, string impersonationAccountKey = null);
        GetManagedInvoicesResponseModel ManagedInvoicesSearch(string payerName = null, string createdBy = null, DateTime? dueDateFrom = null, DateTime? dueDateTo = null, ManagedInvoiceSearchStatusType managedInvoiceSearchStatusType = ManagedInvoiceSearchStatusType.Open, short? page = null, byte? pageSize = null, string impersonationAccountKey = null);
        PostVoidManagedInvoiceResponseModel ManagedInvoicesVoid(string id, string impersonationAccountKey = null);
        string ManagedInvoicesPost(PostCreateManagedInvoicesRequestModel postCreateManagedInvoicesRequestModel, string impersonationAccountKey = null);
        string FinanceManagedInvoices(string id, PostCreateManagedInvoicesFinanceRequestModel postCreateManagedInvoicesFinanceRequestModel, string impersonationAccountKey = null);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ManagedInvoicesApi : IManagedInvoicesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagedInvoicesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ManagedInvoicesApi(String basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagedInvoicesApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ManagedInvoicesApi(Configuration configuration = null)
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
        /// Retrieves the details of a managed invoice.
        /// </summary>
        /// <param name="id">The unique identifier of the managed invoice.</param>
        /// <param name="impersonationAccountKey">The key that allows impersonation of another account for which the managed is being processed. Only specify a value if the account being impersonated is different from the account that is submitting this request.</param>
        /// <returns>The details of the managed invoice.</returns>
        public GetManagedInvoiceResponseModel ManagedInvoicesGet(string id, string impersonationAccountKey = null)
        { 
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling ManagedInvoicesApi->ManagedInvoicesGet");

            var localVarPath = "/api/v2/managedInvoices/{id}";

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

            if (impersonationAccountKey != null) localVarHeaderParams.Add("impersonationAccountKey", Configuration.ApiClient.ParameterToString(impersonationAccountKey)); // header parameter

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (id != null) localVarPathParams.Add("id", Configuration.ApiClient.ParameterToString(id)); // path parameter

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException(localVarStatusCode, "Error calling ManagedInvoicesGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling ManagedInvoicesGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            var headerDict = localVarResponse.Headers.GroupBy(x => x.Name).ToDictionary(g => g.Key, g => string.Join(", ", g.Select(x => x.Value?.ToString())));

            var response = new ApiResponse<GetManagedInvoiceResponseModel>(
                localVarStatusCode,
                headerDict,
                (GetManagedInvoiceResponseModel)Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetManagedInvoiceResponseModel))
            );

            return response.Data;
        }

        /// <summary>
        /// Retrieves a list of Managed invoices based on search parameters.
        /// </summary>
        /// <param name="payerName">When filtering by the payer's name, the name or partial name to match.</param>
        /// <param name="createdBy">When filtering by the creator's name, the name or partial name to match.</param>
        /// <param name="dueDateFrom">When filtering by due date, the earliest permitted date. Default is null.</param>
        /// <param name="dueDateTo">When filtering by due date, the latest permitted date. Default is null.</param>
        /// <param name="managedInvoiceSearchStatusType">The type of managed invoice status search to perform. Default is open.</param>
        /// <param name="page">The page of results to return. Default is 1.</param>
        /// <param name="pageSize">The size of each page. Default is 25, Maximum is 50.</param>
        /// <param name="impersonationAccountKey">The key that allows impersonation of another account for which the managed invoice is being processed. Only specify a value if the account being impersonated is different from the account that is submitting this request.</param>
        /// <returns></returns>
        public GetManagedInvoicesResponseModel ManagedInvoicesSearch(string payerName = null, string createdBy = null, DateTime? dueDateFrom = null, DateTime? dueDateTo = null, ManagedInvoiceSearchStatusType managedInvoiceSearchStatusType = ManagedInvoiceSearchStatusType.Open, short? page = null, byte? pageSize = null, string impersonationAccountKey = null)
        {
            var localVarPath = "/api/v2/managedInvoices";

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
            localVarQueryParams.Add("managedInvoiceSearchStatusType", Configuration.ApiClient.ParameterToString(managedInvoiceSearchStatusType));

            if (payerName != null) localVarQueryParams.Add("payerName", Configuration.ApiClient.ParameterToString(payerName)); // query parameter
            if (createdBy != null) localVarQueryParams.Add("createdBy", Configuration.ApiClient.ParameterToString(createdBy)); // query parameter
            if (dueDateFrom != null) localVarQueryParams.Add("dueDateFrom", Configuration.ApiClient.ParameterToString(dueDateFrom)); // query parameter
            if (dueDateTo != null) localVarQueryParams.Add("dueDateTo", Configuration.ApiClient.ParameterToString(dueDateTo)); // query parameter
            if (page != null) localVarQueryParams.Add("page", Configuration.ApiClient.ParameterToString(page)); // query parameter
            if (pageSize != null) localVarQueryParams.Add("pageSize", Configuration.ApiClient.ParameterToString(pageSize)); // query parameter

            if (impersonationAccountKey != null) localVarHeaderParams.Add("impersonationAccountKey", Configuration.ApiClient.ParameterToString(impersonationAccountKey)); // header parameter

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException(localVarStatusCode, "Error calling ManagedInvoicesSearch: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling ManagedInvoicesSearch: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            var headerDict = localVarResponse.Headers.GroupBy(x => x.Name).ToDictionary(g => g.Key, g => string.Join(", ", g.Select(x => x.Value?.ToString())));

            return new ApiResponse<GetManagedInvoicesResponseModel>(
                localVarStatusCode,
                headerDict,
                (GetManagedInvoicesResponseModel)Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetManagedInvoicesResponseModel))
            ).Data;

        }

        public PostVoidManagedInvoiceResponseModel ManagedInvoicesVoid(string id, string impersonationAccountKey = null)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling ManagedInvoicesApi->ManagedInvoicesVoid");

            var localVarPath = "/api/v2/managedInvoices/{id}/void";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json", "text/json", "application/xml", "text/xml", "application/x-www-form-urlencoded"
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
            if (id != null) localVarPathParams.Add("id", Configuration.ApiClient.ParameterToString(id)); // path parameter

            if (impersonationAccountKey != null) localVarHeaderParams.Add("impersonationAccountKey", Configuration.ApiClient.ParameterToString(impersonationAccountKey)); // header parameter

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode == 400)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<PostVoidManagedInvoiceResponseModel>(localVarResponse.Content);
            }
            else if (localVarStatusCode >= 400)
            {
                var errorResponseModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorResponseModel>(localVarResponse.Content);

                throw new ApiException(localVarStatusCode, errorResponseModel != null ? errorResponseModel.Message : null);
            }

            return new PostVoidManagedInvoiceResponseModel
            {
                VoidManagedInvoiceResponseCode = VoidManagedInvoiceResponseCode.Success
            };
        }

        /// <summary>
        /// Creates Managed Invoice.
        /// </summary>
        /// <param name="postCreateManagedInvoicesRequestModel">The details of the Managed Invoice to be created. In the response, the Id of the created Managed Invoice is the last part of the URI in the location header attribute.</param>
        /// <param name="impersonationAccountKey">The key that allows impersonation of another account for which the managed invoice is being created. Only specify a value if the account being impersonated is different from the account that is submitting this request.</param>
        public string ManagedInvoicesPost(PostCreateManagedInvoicesRequestModel postCreateManagedInvoicesRequestModel, string impersonationAccountKey = null)
        {
            if (postCreateManagedInvoicesRequestModel == null)
                throw new ApiException(400, "Missing required parameter 'postCreateManagedInvoicesRequestModel' when calling ManagedInvoices Api->ManagedInvoicesPost");

            var localVarPath = "/api/v2/managedInvoices";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json", "text/json", "application/xml", "text/xml", "application/x-www-form-urlencoded"
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

            if (impersonationAccountKey != null) localVarHeaderParams.Add("impersonationAccountKey", Configuration.ApiClient.ParameterToString(impersonationAccountKey)); // header parameter

            if (postCreateManagedInvoicesRequestModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(postCreateManagedInvoicesRequestModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = postCreateManagedInvoicesRequestModel; // byte array
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

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

            return localVarResponse.Headers.First(x => x.Name == "Location").Value.ToString().Split('/').Last();

        }

        /// <summary>
        /// Creates Managed Invoice with Financing.
        /// </summary>
        /// <param name="id">The public id of the managed invoice to be edited.</param>
        /// <param name="postCreateManagedInvoicesFinanceRequestModel">The details of the Quote/Invoice to be created. In the response, the Id of the created Quote/Invoice is the last part of the URI in the location header attribute.</param>
        /// <param name="impersonationAccountKey">The key that allows impersonation of another account for which the quote/invoice is being created. Only specify a value if the account being impersonated is different from the account that is submitting this request.</param>
        public string FinanceManagedInvoices(string id, PostCreateManagedInvoicesFinanceRequestModel postCreateManagedInvoicesFinanceRequestModel, string impersonationAccountKey = null)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling ManagedInvoicesApi->FinanceManagedInvoices");
                
            // verify the required parameter 'postTransactionRequestModel' is set
            if (postCreateManagedInvoicesFinanceRequestModel == null)
                throw new ApiException(400, "Missing required parameter 'postCreateManagedInvoicesFinanceRequestModel' when calling ManagedInvoicesApi->FinanceManagedInvoices");

            var localVarPath = "/api/v2/managedInvoices/{id}/finance";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json", "text/json", "application/xml", "text/xml", "application/x-www-form-urlencoded"
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

            if (id != null) localVarPathParams.Add("id", Configuration.ApiClient.ParameterToString(id)); // path parameter

            if (impersonationAccountKey != null) localVarHeaderParams.Add("impersonationAccountKey", Configuration.ApiClient.ParameterToString(impersonationAccountKey)); // header parameter

            if (postCreateManagedInvoicesFinanceRequestModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(postCreateManagedInvoicesFinanceRequestModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = postCreateManagedInvoicesFinanceRequestModel; // byte array
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

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

            return localVarResponse.Headers.First(x => x.Name == "Location").Value.ToString().Split('/').Last();
        }

    }

}
