using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using Microsoft.Extensions.DependencyInjection;

namespace Examples
{
    [TestClass]
    public class ConfigurationTests
    {
        [TestMethod]
        public void TryLog()
        {
            // creates or updates something like D:\Nshan\DotNetPlayGround\EFCoreTest\Examples\bin\Debug\logs\common-2017-01-11.log file
            MyLogger.CommonLog.Trace("kuku");
        }
        [TestMethod]
        public void TryGetAllServices()
        {
            //Microsoft.EntityFrameworkCore.Internal.DbContextServices.get_DatabaseProviderServices.TryGetAllServices
            Assert.Inconclusive();
            //AppContext.BaseDirectory
            //Console.WriteLine(.Count);
            //AppDomain.CurrentDomain.

            //Microsoft.Extensions.DependencyInjection. . .EntityFrameworkServiceCollectionExtensions .AddDbContext()
            //ServiceCollection serviceCollection = new ServiceCollection();
            //var x = serviceCollection.BuildServiceProvider();
            // creates or updates something like D:\Nshan\DotNetPlayGround\EFCoreTest\Examples\bin\Debug\logs\common-2017-01-11.log file
            // ServiceDescriptor
            //MyLogger.CommonLog.Trace("serviceCollection.Count:{}", serviceCollection.Count);
        }
    }
}
