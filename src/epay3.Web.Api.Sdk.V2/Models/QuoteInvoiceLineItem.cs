using System.ComponentModel.DataAnnotations;

namespace epay3.Web.Api.Sdk.V2.Models
{
    public class QuoteInvoiceLineItem
    {
        [Required]
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public bool? Earned { get; set; }
    }
}
