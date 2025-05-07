using System;

namespace epay3.Web.Api.Sdk.V2.Models
{
    public class PostCreateManagedInvoicesRequestModel : PostCreateManagedInvoicesBaseModel
    {
        public string PolicyNumber { get; set; }

        public DateTime? EffectiveDate { get; set; }

        public DateTime? ExpirationDate { get; set; }
    }
}