using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace epay3.Web.Api.Sdk.V2.Models
{
    /// <summary>
    /// Creates an AutoPay for recurring payments.
    /// </summary>
    public class PostAutoPayRequestModel
    {
        /// <summary>
        /// The public token id of each recurring payment.
        /// </summary>
        [JsonProperty("publicTokenId")]
        public string PublicTokenId { get; set; }

        /// <summary>
        /// The search values for a recurring payment.
        /// </summary>
        [JsonProperty("attributeValues")]
        public Dictionary<string, string> AttributeValues { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// The associated email of each recurring payment.
        /// </summary>
        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }
    }
}
