using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;

namespace Examples
{
    [TestClass]
    public class ConfigurationTests
    {
        [TestMethod]
        public void TryLog()
        {
            // creates or updates something like D:\Nshan\DotNetPlayGround\IS_DacFX_Roslyn\Examples\bin\Debug\logs\common-2017-01-11.log file
            MyLogger.CommonLog.Trace("kuku");
        }
        [TestMethod]
        public void TrySSISproject()
        {
            var p = SSISHelper.LoadPackageFromProject("ExistingPackage", DevStudioHelper.SSISprojectPath + @"\bin\Development\SSIS.ispac");
            Assert.IsNotNull(p);
        }
        [TestMethod]
        public void TryGetVS_ProjectPath()
        {
            MyLogger.CommonLog.Trace("Environment.UserInteractive {0}", Environment.UserInteractive);
            MyLogger.CommonLog.Trace("Environment.CurrentDirectory {0}", Environment.CurrentDirectory);
            string codebase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            MyLogger.CommonLog.Trace("codebase {0}", codebase);
            string codebaset = System.Reflection.Assembly.GetExecutingAssembly().GetName(true).CodeBase;
            MyLogger.CommonLog.Trace("codebase {0}", codebaset);
            string codebasef = System.Reflection.Assembly.GetExecutingAssembly().GetName(false).CodeBase;
            MyLogger.CommonLog.Trace("codebase {0}", codebasef);
            MyLogger.CommonLog.Trace("ProjectPath {0}", T4Helper.TemplateDir);

        }
    }
}
