using epay3.Web.Api.Sdk.V2.Models;

namespace epay3.Web.Api.V2.Tests.TestData
{
    public interface IProcessorTestData
    {
        BankAccountInformationModel Ach1 { get; }
        BankAccountInformationModel Ach2 { get; }
        CreditCardInformationModel Amex { get; }
        CreditCardInformationModel Mastercard { get; }
        CreditCardInformationModel Visa { get; }
    }
}