using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

// for smo objects Reference to
// C:\Program Files\Microsoft SQL Server\130\SDK\Assemblies 
// Microsoft.SqlServer.Management.Sdk.Sfc; Microsoft.SqlServer.Smo.dll; Microsoft.SqlServer.SqlEnum.dll; 
// C:\Program Files (x86)\Microsoft SQL Server\130\SDK\Assemblies
// Microsoft.SqlServer.ConnectionInfo.dll

namespace SQLHelper
{
    public class LocalDB
    {
        static Common.IMyLogger localDBlogger = Common.LoggerFactory.GetLogger("localDB");
        public static bool EnsureServer(string connectionString)
        {
            SqlConnectionInfo sqlConnectionInfo = getLocalDBInstanceConn(connectionString);
            ServerConnection sConn = new ServerConnection(sqlConnectionInfo);

            Server server = new Server(sConn);
            try
            {
                Version version = server.Version;
                localDBlogger.Info("Server:{0}; Version:{1}", sqlConnectionInfo.ServerName,version);
            }
            catch(Microsoft.SqlServer.Management.Common.ConnectionFailureException ex)
            {
                localDBlogger.Error(ex, "Server:{0}", sqlConnectionInfo.ServerName);
                return false;
            }
            localDBlogger.Info("server.Databases.Count:{0}", server.Databases.Count);
            foreach(Database db in server.Databases)
            {
                localDBlogger.Info("db.Name:{0}; db.PrimaryFilePath:{1}; db.FileName:{2}", db.Name, db.PrimaryFilePath,db.FileGroups[0].Files[0].Name);
            }
            return true;
        }
        public static bool EnsureDeleted(string connectionString)
        {
            SqlConnectionInfo sqlConnectionInfo = getLocalDBInstanceConn(connectionString);
            ServerConnection sConn = new ServerConnection(sqlConnectionInfo);

            Server server = new Server(sConn);

            SqlConnectionStringBuilder connBuilder = new SqlConnectionStringBuilder(connectionString);
            string dbName = connBuilder.InitialCatalog;
            string dbFileName = connBuilder.AttachDBFilename;

            foreach (Database db in server.Databases)
            {
                //localDBlogger.Info("db.Name:{0}; db.PrimaryFilePath:{1}; db.FileName:{2}", db.Name, db.PrimaryFilePath, db.FileGroups[0].Files[0].Name);
            }

            //server.Databases.;
            server.KillDatabase("");

            //string filePath = connBuilder.AttachDBFilename;

            // System.IO.Path
            //System.IO.File.Exists(filePath);
            //SqlConnection conn = new SqlConnection(connBuilder.ConnectionString);

            return false;
        }
        public static bool EnsureCreated(string connectionString)
        {
            getLocalDBInstanceConn(connectionString);
            return false;
        }

        static private SqlConnectionInfo getLocalDBInstanceConn(string connectionString)
        {
            SqlConnectionStringBuilder connBuilder = new SqlConnectionStringBuilder(connectionString);
            string ds = connBuilder.DataSource;
            if (!ds.ToLower().Contains("localdb") && !ds.ToLower().Contains("sqlexpress"))
            {
                throw new ArgumentException("Not a local db connection", "connectionString");
            }
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            sqlConnectionInfo.ServerName = connBuilder.DataSource;
            sqlConnectionInfo.Authentication = (SqlConnectionInfo.AuthenticationMethod)connBuilder.Authentication;

            return sqlConnectionInfo;
        }
    }
}
