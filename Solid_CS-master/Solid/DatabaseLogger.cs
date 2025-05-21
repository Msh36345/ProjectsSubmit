using System;

namespace Solid_Principle
{
    public class DatabaseLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[DB LOG]: {message} (מדומה)");
        }
    }
}