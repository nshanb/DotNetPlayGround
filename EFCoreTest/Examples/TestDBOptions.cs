using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using CoreDAL;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Examples
{
    [TestClass]
    public class TestDBOptions
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
                // all is good, exepted exception
            }
        }
        [TestMethod]
        public void TryTestDBWithCOnfig()
        {
            DbContextOptions<TestDB> dbContextOptions = new DbContextOptions<TestDB>();
            TestDB context = new TestDB(dbContextOptions);
            //try
            {
                context.Tests.Count();
                Assert.Fail("Shouldn't go so far without configured database provider.");
            }
            //catch (System.InvalidOperationException)
            {
                // all is good, exepted exception
            }
        }
        [TestMethod]
        public void TryControllDB()
        {
            ControllDB context = new ControllDB();
            try
            {
                context.MainConfigs.Count();
                Assert.Fail("Shouldn't go so far without configured database provider.");
            }
            catch (System.InvalidOperationException)
            {
                // all is good, exepted exception
            }
        }
    }
}
//Microsoft.EntityFrameworkCore.Internal.DbContextServices.get_DatabaseProviderServices()
//MyLogger.CommonLog.Trace("connStr: {0}", context.MainConfigs.Count());