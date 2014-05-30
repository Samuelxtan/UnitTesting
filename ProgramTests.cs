using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.IO;
using Malware_FYPJ;

namespace ConsoleApp2.Tests
{

    [TestClass()]
    public class ProgramTests
    {

        //Method for running console app
        private int StartConsoleApplication(string arguments)
        {
            // Initialize process here
            Process proc = new Process();
            proc.StartInfo.FileName = "C:\\inetpub\\wwwroot\\ConsoleApp2\\bin\\Debug\\ConsoleApp2.exe";
            // add arguments as whole string
            proc.StartInfo.Arguments = arguments;

            // use it to start from testing environment
            proc.StartInfo.UseShellExecute = false;

            // redirect outputs to have it in testing console
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;

            // set working directory
            proc.StartInfo.WorkingDirectory = "C:\\inetpub\\wwwroot\\ConsoleApp2\\bin\\Debug\\";

            // start and wait for exit
            proc.Start();
            proc.WaitForExit();

            // get output to testing console.
            System.Console.WriteLine(proc.StandardOutput.ReadToEnd());
            System.Console.Write(proc.StandardError.ReadToEnd());

            // return exit code
            return proc.ExitCode;
        }

        [TestMethod()]

        //Unit Testing for testing console output 
        public void MainTest()
        {
            string text = "No Environment found for this host. Invalid Command";


            Assert.AreEqual(0, StartConsoleApplication("-help"));

            // Check that help information shown correctly.
           Assert.AreEqual(text, Console.Out);
        }

        [TestMethod()]
        //Unit Testing for Uploading sample through console application through console application
        public void SubmitSampleTest()
        {
            Submit.Submit submit = new Submit.Submit();

            Guid id = new Guid("44cee83b-1b51-4819-9f94-a26c05315cf4");

            int bufferLength = 16 * 1024;

            byte[] buffer = new byte[bufferLength];

            var results = submit.SubmitSample("UnitTest", buffer, id, ".exe");

            Assert.AreEqual(results, "Sucessfully submitted for analysis");
        }

        [TestMethod()]
        //Unit Testing for Uploading sample through console application through console application
        public void GetSampleListTest()
        {
            // Assert.IsNotNull();
        }
            //Unit Testing for getting list of sample's MD5 from database
            [TestMethod()]
            public void GetMD5ListTest()
            {

            }

            //Unit Testing for getting list of sample's filetype from database
            [TestMethod()]
            public void GetfiletypeTest()
            {

            }

            //Unit Testing for downloading for all sample's report formats through console application
            [TestMethod()]
            public void DownloadAllReportTest()
            {
                Submit.Submit submit = new Submit.Submit();

                var results = submit.DownloadAllReport("b869b3a637110b8a8d5441b24ab5226a");

                Assert.IsNotNull(results, "File successfully downloaded");
            }

            //Unit Testing for downloading for Sample through console application
            [TestMethod()]
            public void DownloadSampleTest()
            {
                Submit.Submit submit = new Submit.Submit();

                Guid id = new Guid("44cee83b-1b51-4819-9f94-a26c05315cf4");

                int bufferLength = 16 * 1024;

                byte[] buffer = new byte[bufferLength];

                var results = submit.DownloadSample("ce338fe6899778aacfc28414f2d9498b", ".UnitTest");

               Assert.IsNotNull(results, "Sucessfully downloaded");
            }

            //Unit Testing for downloading sample single report through console application
            [TestMethod()]
            public void DownloadReportTest()
            {
                Submit.Submit submit = new Submit.Submit();

                var results = submit.DownloadAllReport("b869b3a637110b8a8d5441b24ab5226a");

               Assert.IsNotNull(results, "File download successfully");
            }

            [TestMethod()]
            public void LogInfoTest()
            {
                Submit.Submit submit = new Submit.Submit();

                var results = submit.Getuserinfo("sam3", "WIN-1K9HLEFOQCT", "IP: 202.12.95.237", "Singapore", "SG", "4/29/2014 3:46:26 PM", "TEST", "Test", "Test");

               Assert.AreEqual("Logged", results);
            }

            [TestMethod()]
            public void GetGUIDTest()
            {
                Submit.Submit submit = new Submit.Submit();

                var results = submit.GetUserGUID("sam3");

                Assert.IsNotNull(results);
            }


            [TestMethod()]
            public void AuthenticateUserTest()
            {
                Submit.Submit submit = new Submit.Submit();

                bool result = submit.AuthenticateUser("sam3", "1234567.");

                Assert.IsTrue(result);
            }

        }
    }
