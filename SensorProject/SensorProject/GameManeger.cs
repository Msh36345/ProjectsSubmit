using System.Security.Cryptography.X509Certificates;

namespace SensorProject;

public static class GameManeger
{
    public static void Start()
    {
        Console.WriteLine(@"
=============================
||  Welcome to sensor game  ||
=============================");
        Thread.Sleep(3000);
        Console.Clear();
        while (true)
        {
            Console.WriteLine(@"
=============================
||           Menu           ||
=============================");
            Console.Write($"1. Investigate Agent\n" +
                              $"2. Add Agent\n" +
                              $"3. Get all Agent\n" +
                              $"4. Get all Sensors\n" +
                              $"Enter your choice : ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Investigate();
                    break;
                case "2":
                    AddAgent();
                    break;
                case "3":
                    AgentManeger.PrintAllAgent();
                    break;
                case "4":
                    SensorManeger.PrintSensors();
                    break;
                default:
                    Console.WriteLine("Invalid choice, please choose again");
                    Thread.Sleep(2000);
                    break;
            }
        }
        
        
        
        
    }

    public static void AddAgent()
    {
        Console.WriteLine(@"
=============================
||   choice agent to add   ||
=============================
||   1. Low Level Agent    ||
=============================");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
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
        Console.WriteLine(@"
=============================
||       Investigate       ||
=============================
||   1. Assigned Sensor    ||
||  2. Check compatibility ||
||         0. Exit         ||
=============================");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                iraniAgent.AssignedSensorToAgenet();
                break;
            case "2":
                iraniAgent.Activate();
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Invalid choice, please choose again");
                Thread.Sleep(2000);
                break;
        }
        

    }
}