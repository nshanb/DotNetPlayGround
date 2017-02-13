using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreDAL;
using Microsoft.Extensions.CommandLineUtils;

namespace ConsoleApp
{
    public class Program
    {
        static IMyLogger PLogger = LoggerFactory.GetLogger("ConsoleApp");
        static void Main(string[] args)
        {
            string command = null;
            int iapp = 0;
            #region command line parser
            CommandLineApplication app = new CommandLineApplication();
            app.Description = "ETL console app";
            app.Name = "app";

            var exit = app.Command("exit", x =>
            {
                x.Name = "exit"; x.Description = "Do nothing.";
                x.OnExecute(() => { command = null; return 1; });
            });
            var init = app.Command("init", x =>
            {
                x.Description = "Ensure that everything is ok. And init if needed.";
                x.OnExecute(() => { command = "init"; return 2; });
            });
            var help = app.Command("help", x =>
            {
                x.Description = "Show this screen.";
                x.OnExecute(() => { app.ShowHelp(); return 0; });
            });
            app.HelpOption("-? | -h | --help");

            if (args.Count() == 0)
            {
                app.ShowHelp();
            }
            else
            {
                try
                {
                    iapp = app.Execute(args);
                }
                catch (CommandParsingException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }

            char[] sep = null;
            while (iapp == 0)
            {
                System.Console.Write("Input the Command:");
                string input = System.Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) break;
                try
                {
                    iapp = app.Execute(input.Split(sep, StringSplitOptions.RemoveEmptyEntries));
                }
                catch (CommandParsingException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            #endregion
            PLogger.Trace("Start. command{0}", command);
            switch (iapp)
            {
                case 0:
                case 1:
                    Console.WriteLine("Do nothing. Exit");
                    break;
                case 2:
                    try
                    {
                        using (var context = new ControllDB(null))
                        {
                            PLogger.Info("Count:{0}", context.MainConfigs.Count());
                        }
                    }
                    catch (Exception ex)
                    {
                        PLogger.Error(ex, "Main Failed.");
                    }
                    break;
                default:
                    Console.WriteLine("Unknown command. Exit");
                    break;
            }
        }
    }
}
