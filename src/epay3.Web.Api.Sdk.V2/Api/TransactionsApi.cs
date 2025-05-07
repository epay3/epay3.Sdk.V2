using epay3.Web.Api.Sdk.V2.Client;
using epay3.Web.Api.Sdk.V2.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace epay3.Web.Api.Sdk.V2.Api
{
    public interface ITransactionsApi
    {
        GetTransactionResponseModel TransactionsGet(long? id, string impersonationAccountKey = null);

        PostTransactionResponseModel TransactionsPost (PostTransactionRequestModel postTransactionRequestModel, string impersonationAccountKey = null);

        PostVoidTransactionResponseModel TransactionsVoid(long id, PostVoidTransactionRequestModel postVoidTransactionRequestModel, string impersonationAccountKey = null);

        PostRefundTransactionResponseModel TransactionsRefund(long id, PostRefundTransactionRequestModel postRefundTransactionRequestModel, string impersonationAccountKey = null);

        GetTransactionsResponseModel TransactionsSearch(DateTime? beginDate = null, DateTime? endDate = null, TransactionSearchType? transactionSearchTypeId = null, decimal? minAmount = null, decimal? maxAmount = null, long? batchId = null, short? page = null, byte? pageSize = null, string impersonationAccountKey = null);

        string TransactionsAuthorize(PostAuthorizeTransactionRequestModel postAuthorizeTransactionRequestModel, string impersonationAccountKey = null);
    }

    public class TransactionsApi : ITransactionsApi
    {
        public TransactionsApi(String basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }
    
        public TransactionsApi(Configuration configuration = null)
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
    
        public Configuration Configuration {get; set;}

        public GetTransactionResponseModel TransactionsGet(long? id, string impersonationAccountKey = null)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling TransactionsApi->TransactionsGet");

            var localVarPath = "/api/v1/transactions/{id}";

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
                throw new ApiException(localVarStatusCode, "Error calling TransactionsGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling TransactionsGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            var headerDict = localVarResponse.Headers.GroupBy(x => x.Name).ToDictionary(g => g.Key, g => string.Join(", ", g.Select(x => x.Value?.ToString())));

            var response = new ApiResponse<GetTransactionResponseModel>(
                localVarStatusCode,
                headerDict,
                (GetTransactionResponseModel)Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetTransactionResponseModel))
            );


            return response.Data;
        }

        public PostTransactionResponseModel TransactionsPost(PostTransactionRequestModel postTransactionRequestModel, string impersonationAccountKey = null)
        {
            // verify the required parameter 'postTransactionRequestModel' is set
            if (postTransactionRequestModel == null)
                throw new ApiException(400, "Missing required parameter 'postTransactionRequestModel' when calling TransactionsApi->TransactionsPost");

            var localVarPath = "/api/v2/Transactions";
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

            if (postTransactionRequestModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(postTransactionRequestModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = postTransactionRequestModel; // byte array
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode == 400)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<PostTransactionResponseModel>(localVarResponse.Content);
            }
            else if (localVarStatusCode >= 400)
            {
                var errorResponseModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorResponseModel>(localVarResponse.Content);

                throw new ApiException(localVarStatusCode, errorResponseModel != null ? errorResponseModel.Message : null);
            }
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            var id = localVarResponse.Headers.First(x => x.Name == "Location").Value.ToString().Split('/').Last();

            return new PostTransactionResponseModel
            {
                Id = long.Parse(id),
                PaymentResponseCode = PaymentResponseCode.Success
            };
        }

        public GetTransactionsResponseModel TransactionsSearch(DateTime? beginDate = null, DateTime? endDate = null, TransactionSearchType? transactionSearchTypeId = null, decimal? minAmount = null, decimal? maxAmount = null, long? batchId = null, short? page = null, byte? pageSize = null, string impersonationAccountKey = null)
        {
            var localVarPath = "/api/v1/transactions";

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

            if (beginDate != null) localVarQueryParams.Add("beginDate", Configuration.ApiClient.ParameterToString(beginDate)); // query parameter
            if (endDate != null) localVarQueryParams.Add("endDate", Configuration.ApiClient.ParameterToString(endDate)); // query parameter
            if (transactionSearchTypeId != null) localVarQueryParams.Add("transactionSearchTypeId", Configuration.ApiClient.ParameterToString(transactionSearchTypeId)); // query parameter
            if (minAmount != null) localVarQueryParams.Add("minAmount", Configuration.ApiClient.ParameterToString(minAmount)); // query parameter
            if (maxAmount != null) localVarQueryParams.Add("maxAmount", Configuration.ApiClient.ParameterToString(maxAmount)); // query parameter
            if (batchId != null) localVarQueryParams.Add("batchId", Configuration.ApiClient.ParameterToString(batchId)); // query parameter
            if (page != null) localVarQueryParams.Add("page", Configuration.ApiClient.ParameterToString(page)); // query parameter
            if (pageSize != null) localVarQueryParams.Add("pageSize", Configuration.ApiClient.ParameterToString(pageSize)); // query parameter

            if (impersonationAccountKey != null) localVarHeaderParams.Add("impersonationAccountKey", Configuration.ApiClient.ParameterToString(impersonationAccountKey)); // header parameter

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException(localVarStatusCode, "Error calling TransactionsSearch: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling TransactionsSearch: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            var headerDict = localVarResponse.Headers.GroupBy(x => x.Name).ToDictionary(g => g.Key, g => string.Join(", ", g.Select(x => x.Value?.ToString())));

            return new ApiResponse<GetTransactionsResponseModel>(
                localVarStatusCode,
                headerDict,
                (GetTransactionsResponseModel)Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetTransactionsResponseModel))
            ).Data;

        }

        public PostVoidTransactionResponseModel TransactionsVoid(long id, PostVoidTransactionRequestModel postVoidTransactionRequestModel, string impersonationAccountKey = null)
        {
            // verify the required parameter 'id' is set
            if (id <= 0)
                throw new ApiException(400, "Missing required parameter 'id' when calling TransactionsApi->TransactionsVoid");

            // verify the required parameter 'postVoidTransactionRequestModel' is set
            if (postVoidTransactionRequestModel == null)
                throw new ApiException(400, "Missing required parameter 'postVoidTransactionRequestModel' when calling TransactionsApi->TransactionsVoid");

            var localVarPath = string.Format("/api/v1/Transactions/{0}/void", id);
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

            if (postVoidTransactionRequestModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(postVoidTransactionRequestModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = postVoidTransactionRequestModel; // byte array
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode == 400)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<PostVoidTransactionResponseModel>(localVarResponse.Content);
            }
            else if (localVarStatusCode >= 400)
            {
                var errorResponseModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorResponseModel>(localVarResponse.Content);

                throw new ApiException(localVarStatusCode, errorResponseModel != null ? errorResponseModel.Message : null);
            }

            return new PostVoidTransactionResponseModel
            {
                ReversalResponseCode = ReversalResponseCode.Success
            };
        }

        public PostRefundTransactionResponseModel TransactionsRefund(long id, PostRefundTransactionRequestModel postRefundTransactionRequestModel, string impersonationAccountKey = null)
        {
            // verify the required parameter 'id' is set
            if (id <= 0)
                throw new ApiException(400, "Missing required parameter 'id' when calling TransactionsApi->TransactionsRefund");

            // verify the required parameter 'postRefundTransactionRequestModel' is set
            if (postRefundTransactionRequestModel == null)
                throw new ApiException(400, "Missing required parameter 'postRefundTransactionRequestModel' when calling TransactionsApi->TransactionsRefund");

            var localVarPath = string.Format("/api/v1/Transactions/{0}/refund", id);
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

            if (postRefundTransactionRequestModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(postRefundTransactionRequestModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = postRefundTransactionRequestModel; // byte array
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode == 400)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<PostRefundTransactionResponseModel>(localVarResponse.Content);
            }
            else if (localVarStatusCode >= 400)
            {
                var errorResponseModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorResponseModel>(localVarResponse.Content);

                throw new ApiException(localVarStatusCode, errorResponseModel != null ? errorResponseModel.Message : null);
            }

            return new PostRefundTransactionResponseModel
            {
                Id = long.Parse(localVarResponse.Headers.First(x => x.Name == "Location").Value.ToString().Split('/').Last()),
                ReversalResponseCode = ReversalResponseCode.Success
            };
        }

        public string TransactionsAuthorize(PostAuthorizeTransactionRequestModel postAuthorizeTransactionRequestModel, string impersonationAccountKey = null)
        {
            // verify the required parameter 'postTransactionRequestModel' is set
            if (postAuthorizeTransactionRequestModel == null)
                throw new ApiException(400, "Missing required parameter 'postAuthorizeTransactionRequestModel' when calling TransactionsApi->TransactionsAuthorize");

            var localVarPath = "/api/v1/Transactions/Authorize";
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

            if (postAuthorizeTransactionRequestModel.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(postAuthorizeTransactionRequestModel); // http body (model) parameter
            }
            else
            {
                localVarPostBody = postAuthorizeTransactionRequestModel; // byte array
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

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
