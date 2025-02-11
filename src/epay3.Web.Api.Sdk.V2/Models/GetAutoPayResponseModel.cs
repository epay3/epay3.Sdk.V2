using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace epay3.Web.Api.Sdk.V2.Models
{
    public class GetAutoPayResponseModel
    {
        /// <summary>
        /// The unique identifier of the AutoPay.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// The token Id that represents the payment method to be used on the payments.
        /// </summary>
        [JsonProperty("tokenId")]
        public string TokenId { get; set; }

        /// <summary>
        /// The attributes associated with the AutoPay.
        /// </summary>
        [JsonProperty("attributes")]
        public Dictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// The email address associated with the AutoPay.
        /// </summary>
        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }
    }
}
