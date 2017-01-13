using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using CoreDAL;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Examples
{
    [TestClass]
    public class TestOptions
    {
        [TestMethod]
        public void TryTestDBWithoutConfig()
        {
            TestDB context = new TestDB();
            try
            {
                context.Tests.Count();
                Assert.Fail("Shouldn't go so far without configured database provider.");
            }
            catch (System.InvalidOperationException)
            {
                // all is good, expected exception
            }
        }
        [TestMethod]
        public void TryTestDBWithConfig_ConstructorArgument()
        {
            DbContextOptionsBuilder<TestDB> dbContextOptionsBuilder = new DbContextOptionsBuilder<TestDB>();
            dbContextOptionsBuilder.UseInMemoryDatabase();
            TestDB context = new TestDB(dbContextOptionsBuilder.Options);
            context.Tests.Count();
        }
        [TestMethod]
        public void TryTestDBWithConfig_OnConfiguring()
        {
            TestDB1 context = new TestDB1();
            context.Tests.Count();
        }
        [TestMethod]
        public void TryTestDBWithConfig_DependencyInjection()
        {
            Assert.Inconclusive();
            //ServiceCollection serviceCollection = new ServiceCollection();
            //var x = serviceCollection.BuildServiceProvider();
            //x.GetServices();
            //.AddDbContext<StringInOnConfiguringContext>()
            //.BuildServiceProvider();
        }
        [TestMethod]
        public void TryControllDBBWithConfig_Factory()
        {
            ControllDB context = new ControllDBContextFactory().Create(null);
            context.MainConfigs.Count();
        }
        [TestMethod]
        public void TryControllDB()
        {
            ControllDB context = new ControllDBContextFactory().Create(null);
            context.MainConfigs.Count();
        }
        [TestMethod]
        public void TestSomething()
        {
            //Microsoft.EntityFrameworkCore.
        }
    }
}
//Microsoft.EntityFrameworkCore.Internal.DbContextServices.get_DatabaseProviderServices()
//MyLogger.CommonLog.Trace("connStr: {0}", context.MainConfigs.Count());