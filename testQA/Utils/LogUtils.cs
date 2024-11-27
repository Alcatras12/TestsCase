using NLog;

namespace testQA.Utils
{
    public static class LogUtils
    {
        public static readonly Logger log = LogManager.GetCurrentClassLogger();

        public static void LogNewTest(string text) => log.Info($"\n \n NEW TEST {text} \n");
    }
}