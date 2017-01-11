using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class LogTimes
    {
        static private Logger logger;
        static int nEvent = 0;
        static LogTimes()
        {
            logger = LogManager.GetLogger("Timings");
        }

        private DateTime _DTM_Begin, _DTM_End;
        private string _description;
        private Stopwatch watch;
        private long[] tickArray;
        private int iArray;
        public LogTimes(string description)
        {
            _description = description;
            if (nEvent == 0)
            {
                logger.Info("StopWatch Frequency = {0} ticks per ms", System.Diagnostics.Stopwatch.Frequency / 1000);
            }
            tickArray = new long[1000];
            iArray = 0;
        }
        public void Begin()
        {
            _DTM_Begin = DateTime.UtcNow;
            watch = Stopwatch.StartNew();
        }
        public void End()
        {
            nEvent++;
            _DTM_End = DateTime.UtcNow;
            watch.Stop();
            long ticks = watch.ElapsedTicks;
            tickArray[iArray] = ticks;
            logger.Info("EvenetId:{0} => {1}", nEvent, _description);
            logger.Info("EvenetId:{0} begin => {1:hh:mm:ss.ffff}", nEvent, _DTM_Begin);
            logger.Info("EvenetId:{0} end   => {1:hh:mm:ss.ffff}", nEvent, _DTM_End);
            long temp = 0;
            for (int i=0; i < iArray; i++)
            {
                logger.Info("EvenetId:{0} BlockTicks:{1}  => {2}", nEvent, i, tickArray[i]-temp);
                temp = tickArray[i];
            }
            logger.Info("EvenetId:{0} duration : {1}(ms) : {2}(ticks)", nEvent, (_DTM_End - _DTM_Begin).TotalMilliseconds, ticks);
        }

        public void Middle()
        {
            tickArray[iArray] = watch.ElapsedTicks;
            iArray++;
        }
    }
}
