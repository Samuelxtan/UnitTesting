using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malware_FYPJ.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;
using System.Data;
using System.Configuration;

namespace Malware_FYPJ.Entity.Tests
{
    [TestClass()]
    public class SampleTests
    {
        [TestMethod]
        public void VerifyThatMyDatabaseConnectionStringExists()
        {
            Assert.IsNotNull(ConfigurationManager.ConnectionStrings["malwrConnectionString"]);
        }

        [TestMethod()]
        public void generateMD5()
        {
                            int bufferLength = 16 * 1024;

                byte[] buffer = new byte[bufferLength];

              var result =  Sample.generateMD5(buffer);

              Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void generateSHA1Test()
        {
            int bufferLength = 16 * 1024;

            byte[] buffer = new byte[bufferLength];

            var result = Sample.generateSHA1(buffer);

            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void checkHashExistenceTest()
        {
            bool result = Sample.checkHashExistence("69620623908a22ba034582c9c9643df8", "EBAFA4CD99644B46B03A48E5420AB453E6425EBA");

            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void insertSampleTest()
        {
            Sample s = new Sample();

            Guid id = new Guid("44cee83b-1b51-4819-9f94-a26c05315cf4");

            s.SampleId = id;
            s.SampleName = "UnitTest";
            DateTime now = DateTime.Now;
            s.SampleInsertDate = now;
            s.UserId = id;
            s.Md5 = "41e5255c-5b85-TEST-b27b-78656ef99e19"; 
            s.Sha1 = "53e5255c-5b85-TEST-b27b-78656ef99e19";
            s.Sha512 = "33e5255c-5b85-TEST-b27b-78656ef99e19";
            s.Filetype = "TEST";


            bool result = Sample.insertSample(s);

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void saveFileToStorageVMTest()
        {
            bool result = Sample.saveFileToStorageVM("C:\\ch.exe");

            Assert.IsNotNull(result);
        }



    }
}
