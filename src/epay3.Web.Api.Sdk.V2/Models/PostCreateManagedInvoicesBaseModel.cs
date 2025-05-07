using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace epay3.Web.Api.Sdk.V2.Models
{
    public abstract class PostCreateManagedInvoicesBaseModel
    {
        [Required]
        public string Payer { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string InvoiceNumber { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public List<QuoteInvoiceLineItem> LineItems { get; set; }

        public List<QuoteInvoiceLineItem> Taxes { get; set; }

        public List<QuoteInvoiceLineItem> Fees { get; set; }

        public bool ShowBreakdownDuringPayment { get; set; }
    }
}
