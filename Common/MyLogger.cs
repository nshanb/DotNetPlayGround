using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Common
{
    public static class LoggerFactory
    {
        static public IMyLogger GetLogger(string loggerName)
        {
            return LogManager.GetLogger(loggerName, typeof(MyLogger)) as IMyLogger;
        }
    }
    public class MyLogger : Logger, IMyLogger
    {
        static private Logger _logger = null;
        static public IMyLogger CommonLog
        {
            get
            {
                if (_logger == null)
                {
                    _logger = LogManager.GetLogger("Common", typeof(MyLogger));
                }
                return _logger as IMyLogger;
            }
        }
    }
}
