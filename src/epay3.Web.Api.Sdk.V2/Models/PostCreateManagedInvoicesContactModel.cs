using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace epay3.Web.Api.Sdk.V2.Models
{
    public class PostCreateManagedInvoicesContactModel
    {
        [Required]
        public string Name { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyNAIC { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        public string Phone { get; set; }
        public string Suite { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}
