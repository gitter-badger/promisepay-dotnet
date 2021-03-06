﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PromisePayDotNet.DTO;
using PromisePayDotNet.Implementations;

namespace PromisePayDotNet.Tests
{
    [TestClass]
    public class UploadTest
    {
        [TestMethod]
        public void UploadDeserialization()
        {
            var jsonStr =
                "{ \"id\": \"a2711d90-ed41-4d12-81d2-000000000002\", \"processed_lines\": 6, \"total_lines\": 6, \"update_lines\": 0, \"error_lines\": 6, \"progress\": 100.0 }";
            var upload = JsonConvert.DeserializeObject<Upload>(jsonStr);
            Assert.IsNotNull(upload);
            Assert.AreEqual("a2711d90-ed41-4d12-81d2-000000000002", upload.Id);
        }

        [TestMethod]
        [Ignore]
        public void CreateUploadSuccessfully()
        {
            
        }

        [TestMethod]
        [Ignore]
        public void ListUploadsSuccessfully()
        {
            var repo = new UploadRepository();
            var uploads = repo.ListUploads();
            Assert.IsNotNull(uploads);
        }

        [TestMethod]
        [Ignore]
        public void GetUploadByIdSuccessfully()
        {
            Assert.Fail();
        }



        [TestMethod]
        [Ignore]
        public void GetStatusSuccessfully()
        {
            Assert.Fail();            
        }

        [TestMethod]
        [Ignore]
        public void StartImportSuccessfully()
        {
            Assert.Fail();            
        }


    }
}
