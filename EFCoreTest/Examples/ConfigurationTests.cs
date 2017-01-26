using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

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
            //Microsoft.Extensions.DependencyInjection.ServiceCollection
            using (CoreDAL.TestMigrationsDB db = new CoreDAL.TestMigrationsDB())
            {
                // Microsoft.EntityFrameworkCore.Infrastructure
                var z = db.GetService<IDatabaseCreator>();
                var y = db.Database.GetService<IDatabaseCreator>();
                Assert.AreSame(z, y);
                var y1 = db.Database.GetService<IDatabaseProvider>();
                var x = db.Database.GetService<IMigrator>();
                var xx = db.GetService<IMigrator>();
                Assert.AreSame(x, xx);
                var x1 = db.Database.GetService<IMigrationsAssembly>();
                var x2 = db.Database.GetService<IHistoryRepository>();
                var x3 = db.GetService<IStateManager>();
                var x4 = db.GetService<IChangeDetector>();
                var x5 = db.GetService<IRelationalConnection>();
                // IExecutionStrategy
                //var x3 = db.Database.GetInfrastructure<Object>();
            }
            //MyLogger.CommonLog.Trace("serviceCollection.Count:{}", serviceCollection.Count);
        }
    }
}
