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
            bool exists = SQLHelper.LocalDB.EnsureServer(connString);
            Assert.IsTrue(exists, "Wrong connection string or server is inaccassible");
        }
        [TestMethod]
        public void TryKnownLocalDBServers()
        {
            string connString = @"Data Source = (LocalDB)\MSSQLLocalDB; Integrated Security = True;";
            bool exists = SQLHelper.LocalDB.EnsureServer(connString);
            connString = @"Data Source = (LocalDB)\v11.0; Integrated Security = True;";
            exists = SQLHelper.LocalDB.EnsureServer(connString);
            connString = @"Data Source = (LocalDB)\v12.0; Integrated Security = True;";
            exists = SQLHelper.LocalDB.EnsureServer(connString);
            connString = @"Data Source = (LocalDB)\v13.0; Integrated Security = True;";
            exists = SQLHelper.LocalDB.EnsureServer(connString);
            connString = @"Data Source = (localdb)\ProjectsV13; Integrated Security = True;";
            exists = SQLHelper.LocalDB.EnsureServer(connString);
            connString = @"Data Source = .\SQLEXPRESS; Integrated Security = True;";
            exists = SQLHelper.LocalDB.EnsureServer(connString);
        }
        [TestMethod]
        public void TryLocalDBCreateDrop()
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
            bool deleted = SQLHelper.LocalDB.EnsureDeleted(connString);
            bool createded = SQLHelper.LocalDB.EnsureCreated(connString);
        }
    }
}
// MSSQL13E.LOCALDB
// MSSQL12E.LOCALDB