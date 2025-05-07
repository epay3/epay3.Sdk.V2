namespace epay3.Web.Api.Sdk.V2.Models
{
    public class QuickQuoteModel
    {
        // Note: this class and its composed types are used in BigQuery export mapping; breaking changes may require updates to the export mapping.

        public string InvoiceId { get; set; }
        public bool IsEligible { get; set; }
        public decimal? DownPayment { get; set; }
        public string FinanceIneligibilityReason { get; set; }
        public int NumberOfInstallments { get; set; }
        public decimal? InstallmentAmount { get; set; }
        public SerializableException Exception { get; set; }
        public string FinanceEligibilityHash { get; set; }
        public string FinanceCompanyName { get; set; }
    }
}
