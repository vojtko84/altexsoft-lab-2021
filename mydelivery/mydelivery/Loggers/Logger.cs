using System;
using System.IO;
using System.Text;
using MyDelivery.Interfaces;

namespace MyDelivery.Loggers
{
    public class Logger : ILogger
    {
        private const string FileToSaveInfo = "log";

        public void SaveIntoFile(string content)
        {
            var dateTime = DateTime.Now;
            var dirInfo = new DirectoryInfo("Logs");
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            var writePath = $"Logs\\{FileToSaveInfo}_{dateTime:dd_MM_yyyy}.txt";
            using var writer = new StreamWriter(writePath, true, Encoding.UTF8);
            writer.WriteLine($"{dateTime:HH:mm:ss} {content}");
        }
    }
}