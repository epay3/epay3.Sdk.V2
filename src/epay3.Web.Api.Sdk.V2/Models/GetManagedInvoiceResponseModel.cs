using System;
using System.Collections.Generic;
using System.Text;

namespace epay3.Web.Api.Sdk.V2.Models
{
    public class GetManagedInvoiceResponseModel
    {
        /// <summary>
        /// The Public identifier of the managed invoice.
        /// </summary>
        public string PublicId { get; set; }
        /// <summary>
        /// The name of the account.
        /// </summary>
        public string AccountName { get; set; }
        /// <summary>
        /// The name of the payer.
        /// </summary>
        public string Payer { get; set; }
        /// <summary>
        /// The date when invoice was created.
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// The user who created the invoice.
        /// </summary>
        public string CreatedByUser { get; set; }
        /// <summary>
        /// The expiration date.
        /// </summary>
        public DateTime? DueDate { get; set; }
        /// <summary>
        /// Represents the current status of the invoice.
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// The sum of all charges specified on invoice.
        /// </summary>
        public decimal InvoiceTotal { get; set; }

        /// <summary>
        /// The date when invoice was cancelled or voided.
        /// </summary>
        public DateTime? CancelDate { get; set; }

        /// <summary>
        /// The date when invoice was completed or paid.
        /// </summary>
        public DateTime? CompleteDate { get; set; }

        /// <summary>
        /// The date when invoice was completed or paid Offplatform.
        /// </summary>
        public DateTime? OffPlatformDate { get; set; }

        /// <summary>
        /// The date when quick quote was retrieved to check for financing.
        /// </summary>
        public DateTime? QuickQuoteDate { get; set; }

        /// <summary>
        /// The date when an email was sent to the payer.
        /// </summary>
        public DateTime? EmailSentDate { get; set; }

        public List<QuoteInvoiceLineItem> LineItems { get; set; }
        public List<QuoteInvoiceLineItem> Taxes { get; set; }
        public List<QuoteInvoiceLineItem> Fees { get; set; }
        public QuoteInvoiceFinancingInfoModel FinancingInfo { get; set; }
        public QuickQuoteModel QuickQuote { get; set; }

    }
}
