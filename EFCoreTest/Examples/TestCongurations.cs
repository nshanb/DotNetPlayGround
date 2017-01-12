using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;

namespace Examples
{
    [TestClass]
    public class TestCongurations
    {
        [TestMethod]
        public void TryLog()
        {
            // creates or updates something like D:\Nshan\DotNetPlayGround\EFCoreTest\Examples\bin\Debug\logs\common-2017-01-11.log file
            MyLogger.CommonLog.Trace("kuku");
        }
    }
}
