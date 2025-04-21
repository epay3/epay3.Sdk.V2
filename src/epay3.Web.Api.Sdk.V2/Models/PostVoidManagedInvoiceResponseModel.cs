using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace epay3.Web.Api.Sdk.V2.Models
{
    public class PostVoidManagedInvoiceResponseModel
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public VoidManagedInvoiceResponseCode VoidManagedInvoiceResponseCode { get; set; }

        [IgnoreDataMember]
        public bool Success
        {
            get
            {
                return VoidManagedInvoiceResponseCode == VoidManagedInvoiceResponseCode.Success;
            }
        }

        public string ErrorMessage { get; set; }
    }
}
