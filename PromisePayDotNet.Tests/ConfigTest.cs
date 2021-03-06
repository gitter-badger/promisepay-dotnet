﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Configuration;

namespace PromisePayDotNet.Tests
{
    [TestClass]
    public class ConfigTest
    {
        [TestMethod]
        public void TestPromisePayConfig()
        {
            var ht = ConfigurationManager.GetSection("PromisePay/Settings") as Hashtable;
            var keyVal = ht["ApiUrl"] as String;
            Assert.AreEqual("https://test.api.promisepay.com", keyVal, "App.config section is wrong");
        }
    }
}
