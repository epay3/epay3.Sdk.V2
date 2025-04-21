using epay3.Web.Api.Sdk.V2.Api;
using epay3.Web.Api.Sdk.V2.Models;
using epay3.Web.Api.V2.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Net;

namespace epay3.Web.Api.V2.Tests
{
    [TestClass]
    public class When_Searching_AutoPays
    {
        private AutoPayApi _autoPayApi;
        private ITestData _testData;
        private byte[] _plainTextBytes;

        [TestInitialize]
        public void Initialize()
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            _testData = new TestData.Processor7();


            _plainTextBytes = System.Text.Encoding.UTF8.GetBytes(_testData.InvoiceKey + ":" + _testData.InvoiceSecret);

            _autoPayApi = new AutoPayApi(_testData.Uri);
            _autoPayApi.Configuration.AddDefaultHeader("Authorization", "Basic " + System.Convert.ToBase64String(_plainTextBytes));
        }

        [TestMethod]
        public void Should_Successfully_Find_AutoPays()
        {
            // Search results can be iterated through, with each returned autoPay coming back in the form of a GetAutoPaysResponseModel.
            var searchResults = _autoPayApi.AutoPaySearch(createDateStart: DateTime.Parse("8/1/2022"),
                pageSize: 5, page: 1, impersonationAccountKey: _testData.ImpersonationAccountKey);
            Assert.IsNotNull(searchResults);

            // Additionally, every parameter when searching for autoPays is optional.
            var searchAllResults = _autoPayApi.AutoPaySearch();
            Assert.IsTrue(searchAllResults.TotalRecords > 0);
            Assert.IsNotNull(searchAllResults);
        }
    }
}