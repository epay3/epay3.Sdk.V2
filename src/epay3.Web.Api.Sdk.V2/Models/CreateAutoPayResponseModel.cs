using Newtonsoft.Json;

namespace epay3.Web.Api.Sdk.V2.Models
{
    public class CreateAutoPayResponseModel
    {
        /// <summary>
        /// The unique identifier of the created AutoPay.
        /// </summary>
        [JsonProperty("autoPayId")]
        public long AutoPayId { get; set; }
    }
}
