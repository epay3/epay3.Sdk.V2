using epay3.Web.Api.Sdk.V2.Models;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace epay3.Web.Api.V2.Tests.TestData
{
    /// <summary>
    /// Uses keys for Account #334 in the sandbox. Can only process credit cards.
    /// </summary>
    public class Processor13 : TestApiSettings, ITestData
    {

        private static readonly IConfiguration _configuration;

        static Processor13()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();
        }
        private static string GetSetting(string key)
        {
            var value = _configuration[$"appSettings:{key}"];
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidOperationException($"Missing configuration for key: {key}");
            }
            return value;
        }
        public override string ImpersonationAccountKey => GetSetting("ImpersonationAccountKey_Processor13");

        public override string Key => GetSetting("ApiKey_Processor13");

        public override string Secret => GetSetting("ApiSecret_Processor13");

        public override string PublicKey => GetSetting("ApiPublicKey_Processor13");

        public BankAccountInformationModel Ach1 => throw new NotImplementedException();

        public BankAccountInformationModel Ach2 => throw new NotImplementedException();

        public CreditCardInformationModel Amex => new CreditCardInformationModel()
        {
            AccountHolder = "John Doe",
            CardNumber = "370000000000002",
            Month = 3,
            Year = 2030,
            Cvc = "7373",
            PostalCode = "54321"
        };

        public CreditCardInformationModel Mastercard => new CreditCardInformationModel()
        {
            AccountHolder = "John Doe",
            CardNumber = "5555341244441115",
            Month = 3,
            Year = 2030,
            Cvc = "737",
            PostalCode = "54321"
        };

        public CreditCardInformationModel Visa => new CreditCardInformationModel
        {
            AccountHolder = "John Doe",
            CardNumber = "4111111145551142",
            Cvc = "737",
            Month = 3,
            Year = 2030,
            PostalCode = "54321"
        };
    }
}