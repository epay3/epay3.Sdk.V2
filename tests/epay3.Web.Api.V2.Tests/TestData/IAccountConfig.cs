namespace epay3.Web.Api.V2.Tests.TestData
{
    public interface IAccountConfig
    {
        string Uri { get; }
        string Key { get; }
        string Secret { get; }
        string PublicKey { get; }
        long ImpersonationOnlyBatchId { get; }
        string ImpersonationAccountKey { get; }
        string InvoiceKey { get; }
        string InvoiceSecret { get; }
        string InvoicesImpersonationAccountKey { get; }
    }
}