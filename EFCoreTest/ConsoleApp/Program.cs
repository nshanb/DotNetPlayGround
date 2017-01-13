using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreDAL;
namespace ConsoleApp
{
    public class Program
    {
        static IMyLogger PLogger = LoggerFactory.GetLogger("ConsoleApp");
        static void Main(string[] args)
        {
            PLogger.Trace("Start.");
            try
            {
                using (var context = new ControllDB(null))
                {
                    PLogger.Info("Count:{0}", context.MainConfigs.Count());
                }
            }
            catch(Exception ex)
            {
                PLogger.Error(ex, "Main Failed.");
            }
        }
    }
}
