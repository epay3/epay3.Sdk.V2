using epay3.Web.Api.Sdk.V2.Models;
using System;

namespace epay3.Web.Api.V2.Tests.TestData
{
    /// <summary>
    /// Uses keys for Account #11 in the sandbox. Can process both credit cards and ACH transactions.
    /// </summary>
    public class Processor7 : TestApiSettings, ITestData
    {
        public BankAccountInformationModel Ach1 => new BankAccountInformationModel
        {
            FirstName = "John",
            LastName = "Smith",
            RoutingNumber = "111000025",
            AccountNumber = "1234567890",
            AccountHolder = "ACME Corp",
            AccountType = AccountType.Corporatechecking
        };

        public BankAccountInformationModel Ach2 => new BankAccountInformationModel
        {
            AccountHolder = "John Smith",
            FirstName = "John",
            LastName = "Smith",
            AccountNumber = "12345",
            RoutingNumber = "021000021",
            AccountType = AccountType.Personalsavings
        };

        public CreditCardInformationModel Amex => new CreditCardInformationModel()
        {
            AccountHolder = "John Doe",
            CardNumber = "371449635398431",
            Cvc = "3714",
            Month = 12,
            Year = DateTime.Now.Year + 1,
            PostalCode = "54321"
        };

        public CreditCardInformationModel Mastercard => new CreditCardInformationModel
        {
            AccountHolder = "John Doe",
            CardNumber = "5555341244441115",
            Cvc = "737",
            Month = 03,
            Year = 2030,
            PostalCode = "54321"
        };

        public CreditCardInformationModel Visa => new CreditCardInformationModel
        {
            AccountHolder = "John Doe",
            CardNumber = "4457119922390123",
            Cvc = "123",
            Month = 12,
            Year = DateTime.Now.Year + 1,
            PostalCode = "54321"
        };
    }
}