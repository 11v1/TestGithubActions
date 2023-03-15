using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestGithubActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGithubActionsTests;
using System.Reflection;
using System.IO;
using System.Threading;
using Microsoft.Win32;

namespace TestGithubActions.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void FooTest()
        {
            /*using var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
            using var key = baseKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion");
            Console.WriteLine($"WINDOWS INSTALLATION TYPE: {key.GetValue("InstallationType")}");*/

            var videoCapture = new VideoCapture();

            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(path, @"..\..\..\..\");
            const string fileName = "MyVideo.mp4";

            using var recorder = videoCapture.Start(fileName, Path.Combine(path, "Artifacts", fileName), Path.Combine(path, "ffmpeg.exe"));
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }
    }
}