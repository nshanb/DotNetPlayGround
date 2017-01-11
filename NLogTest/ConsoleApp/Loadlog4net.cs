using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace ConsoleApp
{
    public class Loadlog4net
    {
        static private log4net.ILog loggerC;
        static private log4net.ILog loggerNC;
        static Loadlog4net()
        {
            loggerC = LogManager.GetLogger("Global");
            loggerNC = LogManager.GetLogger("notConnected");
        }
        public void LoopWithNotConnectedLog(int n)
        {
            LogTimes lt = new LogTimes("Log4Net: Not Connected Logger. n=" + n.ToString());
            // Init

            // Warm Up
            loggerNC.Info("Warm Up");
            // Loop
            lt.Begin();
            for (int i = 0; i <= n; i++)
            {
                loggerNC.Info("kuku");
            }
            lt.End();
        }
        public void LoopWithFileLog(int n)
        {
            LogTimes lt = new LogTimes("Log4Net Loop With FileLog. n=" + n.ToString());
            // Warm Up
            loggerNC.Info("Warm Up");
            // Loop
            lt.Begin();
            for (int i = 0; i <= n; i++)
            {
                loggerC.Info("kuku");
            }
            lt.End();
        }
    }
}
