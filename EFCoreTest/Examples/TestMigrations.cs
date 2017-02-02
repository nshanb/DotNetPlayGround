using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Examples
{
    [TestClass]
    public class TestMigrations
    {
        [TestMethod]
        public void DBCanbeDeletedandCreated()
        {
            using (CoreDAL.TestMigrationsDB db = new CoreDAL.TestMigrationsDB())
            {
                IDatabaseCreator dbCreator = db.GetService<IDatabaseCreator>();
                Assert.IsNotNull(dbCreator);
                IRelationalDatabaseCreator sqldbCreator = db.GetService<IRelationalDatabaseCreator>();
                Assert.IsNotNull(sqldbCreator);
                if (!sqldbCreator.Exists())
                {
                    sqldbCreator.Create();
                }
                sqldbCreator.Delete();
                //int i = db.Database.ExecuteSqlCommand("select top 1 * from aaa");
                //db.Database.OpenConnection();
                //sqldbCreator.CreateTables();

                //db.Database.EnsureCreated();
                //db.Database.EnsureDeleted();
                //db.Database.GetAppliedMigrations();
                //db.Database.GetMigrations();
                //db.Database.GetPendingMigrations();
                //db.Database.Migrate();
            }
        }
        [TestMethod]
        public void DBCreateAndDoSomething()
        {
            using (CoreDAL.TestMigrationsDB db = new CoreDAL.TestMigrationsDB())
            {
                IRelationalDatabaseCreator sqldbCreator = db.GetService<IRelationalDatabaseCreator>();
                if (sqldbCreator.Exists())
                {
                    sqldbCreator.Delete();
                }
                sqldbCreator.Create();
                sqldbCreator.CreateTables();
            }
        }
        [TestMethod]
        public void Schema()
        {
            using (CoreDAL.TestMigrationsDB db = new CoreDAL.TestMigrationsDB())
            {
                Console.WriteLine(db.Model.Relational().Sequences.Count); //?? no elements??
                foreach (var x in db.Model.Relational().Sequences)
                {
                    Console.WriteLine(x);
                }
            }
        }
    }
}
