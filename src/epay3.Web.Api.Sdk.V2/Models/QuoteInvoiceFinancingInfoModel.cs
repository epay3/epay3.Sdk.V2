using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace epay3.Web.Api.Sdk.V2.Models
{
    public class QuoteInvoiceFinancingInfoModel
    {
        public string LineOfBusiness { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public InsuredCustomerType BusinessType { get; set; }
        public decimal MinimumEarnedPercentage { get; set; }
        public int? NumberOfDaysToCancel { get; set; }
        public bool InvoiceAuditable { get; set; }

        public UnderwritingContactModel InsuredContact { get; set; }
        public UnderwritingContactModel CarrierContact { get; set; }
        public UnderwritingContactModel MgaContact { get; set; }
    }
}
