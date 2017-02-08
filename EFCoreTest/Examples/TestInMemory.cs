using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using CoreDAL;
using Model.sync;
using System.Linq;

namespace Examples
{
    [TestClass]
    public class TestInMemory
    {
        [TestMethod]
        public void WriteSaveReadData()
        {
            DbContextOptionsBuilder<ControllDB> dbContextOptionsBuilder = new DbContextOptionsBuilder<ControllDB>();
            dbContextOptionsBuilder.UseInMemoryDatabase();
            using (ControllDB context = new ControllDB(dbContextOptionsBuilder.Options))
            {
                context.SyncTables.Add(new SyncTable() { Name = "kuku", ToCopy = true });
                int n = context.SaveChanges();
                Assert.AreEqual(n, 1);
            }
            using (ControllDB context = new ControllDB(dbContextOptionsBuilder.Options))
            {
                SyncTable entity = context.SyncTables.FirstOrDefault();
                Assert.AreEqual(entity.Name, "kuku");
                Assert.AreEqual(entity.ToCopy, true);
            }
        }
        [TestMethod]
        public void WriteandReadData()
        {
            DbContextOptionsBuilder<ControllDB> dbContextOptionsBuilder = new DbContextOptionsBuilder<ControllDB>();
            dbContextOptionsBuilder.UseInMemoryDatabase();
            using (ControllDB context = new ControllDB(dbContextOptionsBuilder.Options))
            {
                context.MainConfigs.Add(new MainConfig() { Working = "k" });
                int n = context.SaveChanges();
                Assert.AreEqual(n, 1);

                MainConfig entity = context.MainConfigs.FirstOrDefault();
                Assert.AreEqual(entity.Working, "k");
            }
        }
    }
}
