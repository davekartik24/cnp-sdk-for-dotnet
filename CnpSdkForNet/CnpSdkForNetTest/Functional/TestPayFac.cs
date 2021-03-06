﻿using System.Collections.Generic;
using NUnit.Framework;

namespace Cnp.Sdk.Test.Functional
{
    [TestFixture]
    internal class TestPayFac
    {
        private CnpOnline _cnp;
        private Dictionary<string, string> _config;

        [TestFixtureSetUp]
        public void SetUpCnp()
        {
            _config = new Dictionary<string, string>
            {
                {"url", Properties.Settings.Default.url},
                {"reportGroup", "Default Report Group"},
                {"username", "DOTNET"},
                {"version", "11.0"},
                {"timeout", "5000"},
                {"merchantId", "101"},
                {"password", "TESTCASE"},
                {"printxml", "true"},
                {"proxyHost", Properties.Settings.Default.proxyHost},
                {"proxyPort", Properties.Settings.Default.proxyPort},
                {"logFile", Properties.Settings.Default.logFile},
                {"neuterAccountNums", "true"}
            };

            _cnp = new CnpOnline(_config);
        }

        [Test]
        public void PayFacCredit()
        {
            var payFacCredit = new payFacCredit
            {
                // attributes.
                id = "1",
                reportGroup = "Default Report Group",
                // required child elements.
                amount = 1500,
                fundingSubmerchantId = "value for fundingSubmerchantId",
                fundsTransferId = "value for fundsTransferId"
            };

            var response = _cnp.PayFacCredit(payFacCredit);
            Assert.AreEqual("000", response.response);
        }

        [Test]
        public void PayFacDebit()
        {
            var payFacDebit = new payFacDebit
            {
                // attributes.
                id = "1",
                reportGroup = "Planets",
                // required child elements.
                amount = 1500,
                fundingSubmerchantId = "value for fundingSubmerchantId",
                fundsTransferId = "value for fundsTransferId"
            };

            var response = _cnp.PayFacDebit(payFacDebit);
            Assert.AreEqual("000", response.response);
        }
    }
}
