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
