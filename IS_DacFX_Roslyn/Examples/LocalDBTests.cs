using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;

namespace Examples
{
    [TestClass]
    public class LocalDBTests
    {
        [TestMethod]
        public void CeckIfServerExists()
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
            bool exists = SMOHelper.LocalDB.EnsureServer(connString);
            Assert.IsTrue(exists, "Wrong connection string or server is inaccassible");
        }
        [TestMethod]
        public void TryKnownLocalDBServers()
        {
            bool exists = SMOHelper.LocalDB.ListServers();
        }
        [TestMethod]
        public void TryLocalDBCreateDrop()
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
            bool deleted = SMOHelper.LocalDB.EnsureDeleted(connString);
            bool createded = SMOHelper.LocalDB.EnsureCreated(connString);
        }
    }
}
