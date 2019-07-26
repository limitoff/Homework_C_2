using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkCS2_1
{
    class Logger
    {//+
        public static Action<string> WriteMessage;
        public static void LogMessage(string msg)
        {
            WriteMessage(msg);
        }

        public static void LogToConsole(string message)
        {
            Console.WriteLine(message);
        }
    }
    public class FileLogger
    {
        private readonly string logPath;
        public FileLogger(string path)
        {
            logPath = path;
            Logger.WriteMessage += LogMessage;
        }

        public void DetachLog() => Logger.WriteMessage -= LogMessage;

        private void LogMessage(string msg)
        {
            try
            {
                using (var log = File.AppendText(logPath))
                {
                    log.WriteLine(msg);
                    log.Flush();
                }
            }
            catch (Exception)
            {
                // Возникло исключение
            }
        }
    }
}
