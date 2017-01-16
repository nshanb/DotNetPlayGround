using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;

namespace UsefullConfigs
{
    [TestClass]
    public class SimpleConfigs
    {
        [TestMethod]
        public void SimpleLog()
        {
            NLog.Config.XmlLoggingConfiguration xml = new NLog.Config.XmlLoggingConfiguration(@"..\..\Simple.config");
            LogManager.Configuration = xml;
            Logger SimpleLogger = LogManager.GetLogger("Simple");
            SimpleLogger.Trace("This is a Trace");
            SimpleLogger.Warn("This is a Warning");
            try
            {
                int j = 0;
                int i = 1 / j;
            }
            catch(Exception ex)
            {
                SimpleLogger.Error(ex,"This is an Error");
            }
        }
    }
}
