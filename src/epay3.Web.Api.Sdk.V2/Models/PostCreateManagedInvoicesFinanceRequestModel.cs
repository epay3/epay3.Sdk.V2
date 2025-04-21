using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;

namespace epay3.Web.Api.Sdk.V2.Models
{
    public class PostCreateManagedInvoicesFinanceRequestModel
    {
        public string PolicyNumber { get; set; }

        public DateTime EffectiveDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        [Required]
        public string LineOfBusiness { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public InsuredCustomerType BusinessType { get; set; }
        public decimal MinimumEarnedPercentage { get; set; }
        public int? NumberOfDaysToCancel { get; set; }
        public bool InvoiceAuditable { get; set; }

        [Required]
        public PostCreateManagedInvoicesContactModel InsuredContact { get; set; }

        [Required]
        public PostCreateManagedInvoicesContactModel CarrierContact { get; set; }

        public PostCreateManagedInvoicesContactModel MgaContact { get; set; }
    }
}
