using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace epay3.Web.Api.V2.Tests.TestData
{
    public class TestApiSettings : IAccountConfig
    {
        private static readonly IConfiguration _configuration;

        static TestApiSettings()
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

        public string Uri => GetSetting("ApiUri");

        public virtual string Key => GetSetting("ApiKey");

        public virtual string Secret => GetSetting("ApiSecret");

        public virtual string PublicKey => GetSetting("ApiPublicKey");

        public string InvoiceKey => GetSetting("InvoiceApiKey");

        public string InvoiceSecret => GetSetting("InvoiceApiSecret");

        public virtual string ImpersonationAccountKey => GetSetting("ImpersonationAccountKey");

        public string InvoicesImpersonationAccountKey => GetSetting("InvoicesImpersonationAccountKey");

        public long ImpersonationOnlyBatchId => long.Parse(GetSetting("ImpersonationOnlyBatchId"));
    }
}
