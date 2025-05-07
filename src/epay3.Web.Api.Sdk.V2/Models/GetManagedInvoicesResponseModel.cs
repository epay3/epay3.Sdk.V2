using System.Collections.Generic;

namespace epay3.Web.Api.Sdk.V2.Models
{
    public class GetManagedInvoicesResponseModel
    {
        public List<GetManagedInvoiceResponseModel> ManagedInvoices { get; set; }
        public int TotalRecords { get; set; }
    }
}
