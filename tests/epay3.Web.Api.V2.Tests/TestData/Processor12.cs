using epay3.Web.Api.Sdk.V2.Models;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace epay3.Web.Api.V2.Tests.TestData
{
    /// <summary>
    /// Uses keys for Account #333 in the sandbox. Can only process AMEX credit cards.
    /// </summary>
    public class Processor12 : TestApiSettings, ITestData
    {
        private static readonly IConfiguration _configuration;

        static Processor12()
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

        public override string Key => GetSetting("ApiKey_Processor12");

        public override string Secret => GetSetting("ApiSecret_Processor12");

        public override string PublicKey => GetSetting("ApiPublicKey_Processor12");

        public BankAccountInformationModel Ach1 => throw new NotImplementedException();

        public BankAccountInformationModel Ach2 => throw new NotImplementedException();

        public CreditCardInformationModel Amex => new CreditCardInformationModel()
        {
            AccountHolder = "John Doe",
            CardNumber = "341111599241000",
            Month = 12,
            Year = DateTime.Now.Year + 1,
            Cvc = "9395",
            PostalCode = "54321"
        };

        public CreditCardInformationModel Mastercard => throw new NotImplementedException();

        public CreditCardInformationModel Visa => throw new NotImplementedException();
    }
}