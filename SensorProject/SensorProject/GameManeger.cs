using System.Security.Cryptography.X509Certificates;

namespace SensorProject;

public static class GameManeger
{
    public static void Start()
    {
        SensorManeger.Start();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(@"
=============================
||  Welcome to sensor game  ||
=============================");
        Thread.Sleep(200);
        Console.Clear();
        Console.ResetColor();
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(@"
==============================
||           Menu           ||
==============================
||   1. Investigate Agent   ||
||   2. Add Agent           ||
||   3. Get all Agent       ||
||   4. Get all Sensors     ||
||   0. Exit                ||
==============================
Enter your choice : ");
            Console.ResetColor();
            char choice = Console.ReadKey().KeyChar;
            Thread.Sleep(500);
            Console.WriteLine();
            switch (choice)
            {
                case '1':
                    Investigate();
                    break;
                case '2':
                    AddAgent();
                    break;
                case '3':
                    AgentManeger.PrintAllAgent();
                    break;
                case '4':
                    SensorManeger.PrintSensors();
                    break;
                case '0':
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(@"
=============================
||         Bye Bye         ||
=============================");
                    return;
                default:
                    Console.WriteLine("Invalid choice, please choose again");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }

    public static void AddAgent()
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write(@"
=============================
||   choice agent to add   ||
=============================
||   1. Low Level Agent    ||
=============================
Enter your choice : ");
        Console.ResetColor();
        char choice = Console.ReadKey().KeyChar;
        Thread.Sleep(200);
        Console.WriteLine();        switch (choice)
        {
            case '1':
                AgentManeger.AddAgent(new LowLevelAgent());
                break;
            default:
                Console.WriteLine("Invalid choice, please choose again");
                Thread.Sleep(2000);
                break;
        }
    }

    public static void Investigate()
    {
        IraniAgent iraniAgent = AgentManeger.SelectAgent();
        if (iraniAgent==null)
        {
            Thread.Sleep(2000);
            return;
        }

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(@"
==============================
||       Investigate       ||
==============================
||  1. Assigned Sensor      ||
||  2. Check compatibility  ||
||  3. Get assigned sensors || 
||  0. Exit                 ||
==============================
Enter your choice : ");
            Console.ResetColor();
            char choice = Console.ReadKey().KeyChar;
            Thread.Sleep(1000);
            Console.WriteLine();            switch (choice)
            {
                case '1':
                    iraniAgent.AssignedSensorToAgenet();
                    break;
                case '2':
                    iraniAgent.Activate();
                    break;
                case '3':
                    iraniAgent.ShowAssignedSensors();
                    break;
                case '0':
                    return;
                default:
                    Console.WriteLine("Invalid choice, please choose again");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }
}