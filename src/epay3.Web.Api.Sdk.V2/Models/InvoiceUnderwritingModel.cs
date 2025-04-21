using System;

namespace epay3.Web.Api.Sdk.V2.Models
{
    public class InvoiceUnderwritingModel
    {
        public string OriginalLineOfBusinessCode { get; set; }
        public string LineOfBusinessCode { get; set; }
        public decimal? EarnedTaxes { get; set; }
        public decimal? EarnedFees { get; set; }
        public decimal? UnearnedTaxes { get; set; }
        public decimal? UnearnedFees { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public InsuredCustomerType InsuredCustomerType { get; set; }
        public bool IsEndorsement { get; set; }
        public bool IsAgencyBill { get; set; }
        public bool IsAlreadyFinanced { get; set; }
        public UnderwritingContactModel InsuredContact { get; set; }
        public UnderwritingContactModel CarrierContact { get; set; }
        public UnderwritingContactModel MgaContact { get; set; }
        public UnderwritingContactModel RetailAgentContact { get; set; }
        public string AgencySignatory { get; set; }
        public decimal MinimumEarnedPercentage { get; set; }
        public int? NumberOfDaysToCancel { get; set; }
        public bool? IsAuditable { get; set; }

        public InvoiceUnderwritingModel()
        {
            InsuredContact = new UnderwritingContactModel() { Country = 1 };
            CarrierContact = new UnderwritingContactModel() { Country = 1 };
            MgaContact = new UnderwritingContactModel() { Country = 1 };
            RetailAgentContact = new UnderwritingContactModel() { Country = 1 };
        }
    }

    public class UnderwritingContactModel : AddressModel
    {
        public string Name { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyNAIC { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public new State? State { get; set; }
    }
}
