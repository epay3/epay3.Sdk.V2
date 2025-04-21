using epay3.Web.Api.Sdk.V2.Api;
using epay3.Web.Api.Sdk.V2.Models;
using epay3.Web.Api.V2.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;

namespace epay3.Web.Api.V2.Tests
{
    [TestClass]
    public class ManagedInvoicesFixture
    {
        private ManagedInvoicesApi _managedInvoicesApi;
        private ITestData _testData;

        [TestInitialize]
        public void Initialize()
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            _testData = new TestData.Processor7();

            _managedInvoicesApi = new ManagedInvoicesApi(_testData.Uri);

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(_testData.Key + ":" + _testData.Secret);
            _managedInvoicesApi.Configuration.AddDefaultHeader("Authorization", "Basic " + System.Convert.ToBase64String(plainTextBytes));

            _testData = new TestData.Processor7();
        }

        [TestMethod]
        public void Should_Successfully_Find_Managed_Invoices()
        {

            var searchAllResults = _managedInvoicesApi.ManagedInvoicesSearch();
            Assert.IsTrue(searchAllResults.TotalRecords > 0);
            Assert.IsNotNull(searchAllResults);
        }

        [TestMethod]
        public void Should_Create_And_Get()
        {
            var postCreateManagedInvoicesRequestModel = new PostCreateManagedInvoicesRequestModel
            {
                Payer = "A T",
                EmailAddress = "test@example.com",
                Amount = 4874.91M,
                CustomerName = "Test",
                InvoiceNumber = "112120",
                DueDate = DateTime.Now, 
                LineItems = new List<QuoteInvoiceLineItem>
                {
                    new QuoteInvoiceLineItem
                    {
                        Description = "Test",
                        Amount = 4874.91M,
                        Earned = true
                    }
                }
            };

            var createdId = _managedInvoicesApi.ManagedInvoicesPost(postCreateManagedInvoicesRequestModel);
            var gotten = _managedInvoicesApi.ManagedInvoicesGet(createdId);

            Assert.IsNotNull(gotten);
        }

        [TestMethod]
        public void Should_Successfully_Process_And_Void_Managed_Invoice()
        {
            var postCreateManagedInvoicesRequestModel = new PostCreateManagedInvoicesRequestModel
            {
                Payer = "A T",
                EmailAddress = "test@example.com",
                Amount = 4874.91M,
                CustomerName = "Test",
                InvoiceNumber = "112120",
                DueDate = DateTime.Now,
                LineItems = new List<QuoteInvoiceLineItem>
                {
                    new QuoteInvoiceLineItem
                    {
                        Description = "Test",
                        Amount = 4874.91M,
                        Earned = true
                    }
                }
            };

            var response = _managedInvoicesApi.ManagedInvoicesPost(postCreateManagedInvoicesRequestModel, null);

            // Should return a valid Id.
            Assert.IsNotNull(response);

            // Should successfully void a managed invoice.
            Assert.AreEqual(VoidManagedInvoiceResponseCode.Success, _managedInvoicesApi.ManagedInvoicesVoid(response, null).VoidManagedInvoiceResponseCode);

            var getManagedInvoiceResponseModel = _managedInvoicesApi.ManagedInvoicesGet(response);

            Assert.IsNotNull(getManagedInvoiceResponseModel);
            Assert.AreEqual(4874.91M, getManagedInvoiceResponseModel.InvoiceTotal);

            // Should not be able to void the managed invoice more than once.
            Assert.AreEqual(VoidManagedInvoiceResponseCode.PreviouslyVoided, _managedInvoicesApi.ManagedInvoicesVoid(response, null).VoidManagedInvoiceResponseCode);
        }

        [TestMethod]
        public void Should_Succesfully_Finance_Managed_Invoice()
        {
            var postCreateManagedInvoicesRequestModel = new PostCreateManagedInvoicesRequestModel
            {
                Payer = "A T",
                EmailAddress = "test@example.com",
                Amount = 4874.91M,
                CustomerName = "Test",
                InvoiceNumber = "112120",
                DueDate = DateTime.Now,
                LineItems = new List<QuoteInvoiceLineItem>
                {
                    new QuoteInvoiceLineItem
                    {
                        Description = "Test",
                        Amount = 4874.91M,
                        Earned = true
                    }
                }
            };

            var managedInvoiceId = _managedInvoicesApi.ManagedInvoicesPost(postCreateManagedInvoicesRequestModel, null);

            // Should return a valid managed invoice id.
            Assert.IsNotNull(managedInvoiceId);

            var postCreateManagedInvoicesFinanceRequestModel = new PostCreateManagedInvoicesFinanceRequestModel
            {
                PolicyNumber = "12345",
                EffectiveDate = DateTime.Now,
                ExpirationDate = DateTime.Now,
                LineOfBusiness = "AGENT",
                BusinessType = InsuredCustomerType.Commercial,
                InsuredContact = new PostCreateManagedInvoicesContactModel
                {
                    Name = "Test",
                    State = "AL"
                },
                CarrierContact = new PostCreateManagedInvoicesContactModel
                { 
                    Name = "Test",
                    State = "AL"
                }
            };

            var financeManagedInvoiceId = _managedInvoicesApi.FinanceManagedInvoices(managedInvoiceId, postCreateManagedInvoicesFinanceRequestModel, null);

            // Should return a valid finance manage invoice id.
            Assert.IsNotNull(financeManagedInvoiceId);
        }

    }
}