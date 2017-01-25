using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Examples
{
    [TestClass]
    public class ExamineMSTest
    {
        // order => constructor, [TestInitialize], [TestMethod], [TestCleanup]
        //
        //
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
    }
}
