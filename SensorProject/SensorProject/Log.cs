namespace SensorProject;

public static class Log
{
    public static void AddLog(string log)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        // Console.WriteLine(log);
        Console.ResetColor();
    }
}