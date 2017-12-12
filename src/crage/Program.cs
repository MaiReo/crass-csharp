using Crass.PluginCore;
using System;
using System.Linq;

namespace Crass.Crage
{
    class Program
    {

        public static CrageCmdArgs CmdArgs { get; private set; }

        static int Main(string[] args)
        {
            CmdArgs = ParseArgs(args);
            LogHelper.SetLogger(CmdArgs);
            PrintProgramInfo();
            if (!CmdArgs.IsValid())
            {
                PrintUsage();
                PrintArgsError();
                return -1;
            }
            PrintPluginInfo();
            var crage = Crage.Process(CmdArgs);
            crage.PrintContent();
            try
            {
                crage.SaveContent(CmdArgs);
            }
            catch (Exception ex)
            {
                LogHelper.VerboseLine(ex.ToString());
                return -2;
            }
            return 0;
        }

        private static void PrintPluginInfo()
        {
            LogHelper.VerboseLine("------------------------------");
            LogHelper.VerboseLine($"Loaded plugin count:{PluginHost.Current.Plugins.Count()}");

            foreach (var plugin in PluginHost.Current.Plugins)
            {
                var metaData = plugin.GetMetadata();
                if (metaData == null) continue;
                LogHelper.VerboseLine("------------------------------");
                LogHelper.VerboseLine(metaData.ToString());
            }
            LogHelper.VerboseLine("------------------------------");
        }

        private static void PrintArgsError() => LogHelper.Info("Syntax error, please read FAQ and INSTALL for more help information");

        private static void PrintProgramInfo() => LogHelper.Verbose(ProgramInfo.Current.ToString());

        private static void PrintUsage() => LogHelper.Info(ProgramUsage.Current.ToString());

        private static CrageCmdArgs ParseArgs(string[] args)
        {
            var cmdArg = new CrageCmdArgs();
            try
            {
                for (int i = 0; i < args.Length; i++)
                {
                    switch (args[i])
                    {
                        case "-d":
                            cmdArg.PackageDir = args[++i];
                            break;
                        case "-I":
                            cmdArg.PluginName = args[++i];
                            break;
                        case "-l":
                            cmdArg.PackageIndex = args[++i];
                            break;
                        case "-o":
                            cmdArg.OutputDir = args[++i];
                            break;
                        case "-p":
                            cmdArg.PackagePath = args[++i];
                            break;
                        case "-q":
                        case "--quiet":
                            cmdArg.Quiet = true;
                            break;
                        case "-v":
                            cmdArg.Verbose = true;
                            break;
                        default:
                            break;
                    }
                }

            }
            catch (IndexOutOfRangeException)
            {
                cmdArg = null;
            }
            return cmdArg;
        }
    }
}
