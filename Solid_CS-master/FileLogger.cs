using System;
using System.IO;

namespace Solid_Principle
{
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            File.WriteAllText("log.txt", message);
        }
    }
}