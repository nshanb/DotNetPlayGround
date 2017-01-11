using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Checker
    {
        static public void CheckEmpty()
        {
            int i = 10000000;
            Loadlog4net l4n = new Loadlog4net();
            LoadNLog nl = new LoadNLog();
            LoopEmpty(i);
            l4n.LoopWithNotConnectedLog(i);
            nl.LoopWithNotConnectedLog(i);
        }

        static public void CheckFileTarget()
        {
            int i = 1000;
            Loadlog4net l4n = new Loadlog4net();
            LoadNLog nl = new LoadNLog();
            l4n.LoopWithFileLog(i);
            nl.LoopWithFileLog(i);
        }
        static public void LoopEmpty(int n)
        {
            LogTimes lt = new LogTimes("Empty Loop. n=" + n.ToString());
            lt.Begin();
            for (int i = 0; i <= n; i++)
            {

            }
            lt.End();
        }

    }
}
