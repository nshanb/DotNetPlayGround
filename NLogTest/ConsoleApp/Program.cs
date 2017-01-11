using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Checker.CheckEmpty();
            Checker.CheckFileTarget();
            //CheckFileAsyncLog();
            //CheckSteadyState();
            Console.WriteLine("Press any key to Continue.");
            Console.ReadLine();
        }

        private static void CheckSteadyState()
        {
            LoadNLog l = new LoadNLog();
            int n = 10000;
            l.LoopWithFileLogIntermidiateTimings(n, 1000);
        }

        static void CheckFileAsyncLog()
        {
            LoadNLog l = new LoadNLog();
            l.LoopWithFileAsyncLog(100000);
        }
    }
}
