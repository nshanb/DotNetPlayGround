using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Common
{
    public class MyLogger : Logger, IMyLogger
    {
        static private Logger _logger = null;
        static public IMyLogger CommonLog
        {
            get
            {
                if (_logger == null)
                {
                    _logger = LogManager.GetLogger("CommonLog", typeof(MyLogger));
                }
                return _logger as IMyLogger;
            }
        }
    }
}
