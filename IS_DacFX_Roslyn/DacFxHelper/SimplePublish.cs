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
        public static void PublishfromDacpacWithTrace(string dacpacFilePath, string connString)
        {
            DacPackage package = DacPackage.Load(dacpacFilePath);
            dacFXlogger.Trace("package.Name:{0}", package.Name);
            System.Data.SqlClient.SqlConnectionStringBuilder connStrBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder(connString);
            dacFXlogger.Trace("DataSource:{0}; InitialCatalog:{1}", connStrBuilder.DataSource, connStrBuilder.InitialCatalog);
            DacServices service = new DacServices(connString);
            service.Message += new EventHandler<DacMessageEventArgs>(logDacMessage);
            service.ProgressChanged += ProgressChanged;
            PublishOptions options = new PublishOptions();
            options.GenerateDeploymentReport = true;
            PublishResult result = service.Publish(package, "kuku", options);
            string createScript = result.DeploymentReport;
            dacFXlogger.Trace(createScript);
        }
        private static void ProgressChanged(object o, DacProgressEventArgs dpe)
        {
            dacFXlogger.Trace("OperationId:{0}; Status:{1}; {2}", dpe.OperationId, dpe.Status, dpe.Message);
        }
        private static void logDacMessage(object o, DacMessageEventArgs dme)
        {
            switch (dme.Message.MessageType)
            {
                case DacMessageType.Message:
                    dacFXlogger.Trace("M {0}:{1} {2}", dme.Message.Prefix, dme.Message.Number, dme.Message.Message);
                    break;
                case DacMessageType.Warning:
                    dacFXlogger.Warn("M {0}:{1} {2}", dme.Message.Prefix, dme.Message.Number, dme.Message.Message);
                    break;
                case DacMessageType.Error:
                    dacFXlogger.Error("M {0}:{1} {2}", dme.Message.Prefix, dme.Message.Number, dme.Message.Message);
                    break;
                default:
                    throw new Exception("Unknown DacMessageType.");
            }
        }
    }
}

// https://blogs.msdn.microsoft.com/ssdt/2013/12/23/dacfx-public-model-tutorial/