using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Examples
{
    [TestClass]
    public class DacFXpublishTests
    {
        [TestMethod]
        public void TryCreateDBScript()
        {
            string dacpacPath = DevStudioHelper.TestDBprojectPath + @"\bin\debug\testDB.dacpac";
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["dacFXTest"].ConnectionString;
            DacFxHelper.SimplePublish.CreateScriptfromDacpac(dacpacPath, connString);
        }
        [TestMethod]
        public void TryCreateDBScript1()
        {
            string dacpacPath = DevStudioHelper.TestDBprojectPath + @"\bin\debug\testDB.dacpac";
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["dacFXTest"].ConnectionString;
            DacFxHelper.SimplePublish.CreateScriptfromDacpacforDB(dacpacPath, connString);
        }
        [TestMethod]
        public void TryPublish()
        {
            string dacpacPath = DevStudioHelper.TestDBprojectPath + @"\bin\debug\testDB.dacpac";
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["dacFXTest"].ConnectionString;
            DacFxHelper.SimplePublish.PublishfromDacpac(dacpacPath, connString);
        }
        [TestMethod]
        public void TryPublishWithTrace()
        {
            string dacpacPath = DevStudioHelper.TestDBprojectPath + @"\bin\debug\testDB.dacpac";
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["dacFXTest"].ConnectionString;
            DacFxHelper.SimplePublish.PublishfromDacpacWithTrace(dacpacPath, connString);
        }
    }
}
