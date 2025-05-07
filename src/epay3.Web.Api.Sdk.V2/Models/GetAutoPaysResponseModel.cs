using System.Collections.Generic;

namespace epay3.Web.Api.Sdk.V2.Models
{
    public class GetAutoPaysResponseModel
    {
        public List<GetAutoPayResponseModel> AutoPays { get; set; }
        public int TotalRecords { get; set; }
    }
}
