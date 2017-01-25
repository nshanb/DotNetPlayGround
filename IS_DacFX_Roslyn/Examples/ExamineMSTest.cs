using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Examples
{
    [TestClass]
    public class ExamineMSTest
    {
        // order => [AssemblyInitialize]
        //       => constructor, [ClassInitialize], [TestInitialize], [TestMethod], [TestCleanup], 
        //       => constructor, [TestInitialize], [TestMethod], [TestCleanup], [ClassCleanup]
        //       => [AssemblyCleanup]
        static Common.IMyLogger logger = Common.MyLogger.CommonLog;
        public ExamineMSTest()
        {
            // class is constructed for each TestMethod
            logger.Trace("From constructor");
        }
        [TestMethod]
        public void TraceMethodCallSequence1()
        {
            logger.Trace("From [TestMethod] TraceMethodCallSequence1");
        }
        [TestMethod]
        public void TraceMethodCallSequence2()
        {
            logger.Trace("From [TestMethod] TraceMethodCallSequence2");
        }
        [TestInitialize]
        public void Init()
        {
            logger.Trace("From [TestInitialize]");
        }
        [TestCleanup]
        public void Clean()
        {
            logger.Trace("From [TestCleanup]");
        }
        [ClassInitialize]
        static public void ClassInit(TestContext context)
        {
            logger.Trace("From [ClassInitialize]");
        }
        [ClassCleanup]
        static public void ClassClean()
        {
            logger.Trace("From [ClassCleanup]");
        }
        [AssemblyInitialize]
        static public void AssInit(TestContext context)
        {
            logger.Trace("From [AssemblyInitialize]");
        }
        [AssemblyCleanup]
        static public void AssClean()
        {
            logger.Trace("From [AssemblyCleanup]");
        }
    }
}
