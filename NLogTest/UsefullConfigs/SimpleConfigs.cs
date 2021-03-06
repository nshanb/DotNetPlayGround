﻿using System;
using System.Diagnostics;
using System.Net.Http;
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
            catch (Exception ex)
            {
                SimpleLogger.Error(ex, "This is an Error");
            }
        }
        [TestMethod]
        public void LogByLoggerName()
        {
            NLog.LayoutRenderers.LayoutRenderer.Register("GlobalSequenceID", (logEvent) => logEvent.SequenceID);
            NLog.Config.XmlLoggingConfiguration xml = new NLog.Config.XmlLoggingConfiguration(@"..\..\Simple1.config");
            LogManager.Configuration = xml;
            Logger SimpleLogger = LogManager.GetLogger("Simple");
            Logger SimpleLogger1 = LogManager.GetLogger("SimpleAnother");
            SimpleLogger.Trace("This is a Trace");
            SimpleLogger.Warn("This is a Warning");
            SimpleLogger1.Trace("This is a Trace");
            SimpleLogger1.Warn("This is a Warning");
        }

        [TestMethod]
        public void ConnectToWindowsEvents()
        {
            NLog.Config.XmlLoggingConfiguration xml = new NLog.Config.XmlLoggingConfiguration(@"..\..\forevents.config");
            LogManager.Configuration = xml;

            //System.Diagnostics.Tracing.

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://play-ground-docdb.documents.azure.com/");
            var result = httpClient.GetAsync("");
            var response = result.Result;

            Console.WriteLine(response);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);

        }
    }
}
