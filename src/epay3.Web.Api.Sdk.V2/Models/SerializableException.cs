namespace epay3.Web.Api.Sdk.V2.Models
{
    public class SerializableException
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public SerializableException InnerSerializableException { get; set; }
    }
}
