using System;
using System.IO;

namespace Solid_Principle
{
    public class FileLogger : ILogger
    {public string message = "**log**";
    
        public void Log(string message)
        {
            File.WriteAllText("log.txt : ", message);
        }

        public string RetrnLog()
        {
            return message;
        }
    }
}