using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class LoadNLog
    {
        static private Logger loggerC;
        static private Logger loggerA;
        static LoadNLog()
        {
            LogManager.ThrowConfigExceptions = true;
            LogManager.Configuration.Variables["myLogN"] = "1";
            //LogManager.ReconfigExistingLoggers();
            loggerC = LogManager.GetLogger("Connected");
            loggerA = LogManager.GetLogger("ConnectedAsync");
            //var x = new NLog.Config.XmlLoggingConfiguration("");
            //LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration("");
            // warmup TODO nsb
        }
        public void LoopWithNotConnectedLog(int n)
        {
            LogTimes lt = new LogTimes("NLog: Not Connected Logger. n=" + n.ToString());
            // Init
            Logger loggerNC;
            loggerNC = LogManager.GetLogger("notConnected");
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
            LogTimes lt = new LogTimes("NLog: Loop With File Log. n=" + n.ToString());
            // Warm Up
            loggerC.Info("Warm Up");
            // Loop
            lt.Begin();
            for (int i = 0; i <= n; i++)
            {
                loggerC.Info("kuku");
            }
            lt.End();
        }
        public void LoopWithFileLogIntermidiateTimings(int n, int nBlock)
        {
            LogTimes lt = new LogTimes("Loop With File Log. n=" + n.ToString() + "  nBlock=" + nBlock.ToString());
            lt.Begin();
            int iBlock = 0;
            for (int i = 0; i <= n; i++, iBlock++)
            {
                loggerC.Info("kuku");
                if (iBlock == nBlock)
                {
                    lt.Middle();
                    iBlock = 0;
                }
            }
            lt.End();
        }
        public void LoopWithFileAsyncLog(int n)
        {
            LogTimes lt = new LogTimes("Loop With FileAsync Log. n=" + n.ToString());
            lt.Begin();
            for (int i = 0; i <= n; i++)
            {
                loggerA.Info("kuku");
            }
            lt.End();
        }
        public void Loop<T>(Prepare<T> p, Loader<T> l, string description, int n)
        {
            LogTimes lt = new LogTimes(string.Format("{0}. n={1}", description, n));
            T t = p();
            lt.Begin();
            for (int i = 0; i <= n; i++)
            {
                l(t);
            }
            lt.End();
        }
    }
    public delegate T Prepare<T>();
    public delegate void Loader<T>(T t);
}
