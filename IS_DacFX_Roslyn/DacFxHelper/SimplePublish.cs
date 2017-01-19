using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Dac;

namespace DacFxHelper
{
    public class SimplePublish
    {
        static Common.IMyLogger dacFXlogger = Common.LoggerFactory.GetLogger("dacFX");
        public static void CreateScriptfromDacpac(string dacpacFilePath, string connString)
        {
            DacPackage package = DacPackage.Load(dacpacFilePath);
            dacFXlogger.Trace("package.Name:{0}", package.Name);
            string createScript = DacServices.GenerateCreateScript(package, "kuku");
            dacFXlogger.Trace(createScript);
        }
        public static void CreateScriptfromDacpacforDB(string dacpacFilePath, string connString)
        {
            DacPackage package = DacPackage.Load(dacpacFilePath);
            dacFXlogger.Trace("package.Name:{0}", package.Name);
            DacServices service = new DacServices(connString);
            string createScript = service.GenerateDeployScript(package, "kuku");
            dacFXlogger.Trace(createScript);
        }
        public static void PublishfromDacpac(string dacpacFilePath, string connString)
        {
            DacPackage package = DacPackage.Load(dacpacFilePath);
            dacFXlogger.Trace("package.Name:{0}", package.Name);
            DacServices service = new DacServices(connString);
            PublishOptions options = new PublishOptions();
            options.GenerateDeploymentReport = true;
            PublishResult result = service.Publish(package, "kuku", options);
            string createScript = result.DeploymentReport;
            dacFXlogger.Trace(createScript);
        }
    }
}
// https://blogs.msmvps.com/deborahk/deploying-a-dacpac-with-dacfx-api/