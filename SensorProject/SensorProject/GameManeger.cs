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
            Thread.Sleep(300);
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
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write(@"
===============================
||    choice agent to add    ||
===============================
||   1. Foot Soldier         ||
||   2. Squad Leader         ||
||   3. Senior Commander     ||
||   4. Organization Leader  ||
===============================
Enter your choice : ");
            Console.ResetColor();
            char choice = Console.ReadKey().KeyChar;
            Thread.Sleep(200);
            Console.WriteLine();
            switch (choice)
            {
                case '1':
                    if (AgentManeger.check == 0)
                    {
                        AgentManeger.check++;
                    }
                    AgentManeger.AddAgent(new FootSoldier()); 
                    return;
                case '2':
                    if (AgentManeger.check < 1)
                    {
                        Console.WriteLine("You must deploy a Foot Soldier agent first.");
                        break;
                    }
                    else
                    {
                        AgentManeger.AddAgent(new SquadLeader());
                        if (AgentManeger.check<2)
                        {
                            AgentManeger.check++;
                        }
                        return;
                    }
                case '3':
                    if (AgentManeger.check < 2)
                    {
                        Console.WriteLine("You must deploy a Squad Leader agent first.");
                        break;
                    }
                    else
                    {
                        AgentManeger.AddAgent(new SeniorCommander());
                        if (AgentManeger.check<3)
                        {
                            AgentManeger.check++;
                        }
                        return;
                    }
                case '4':
                    if (AgentManeger.check < 3)
                    {
                        Console.WriteLine("You must deploy a Senior Commander agent first.");
                        break;
                    }
                    else
                    {
                        AgentManeger.AddAgent(new OrganizationLeader());
                        if (AgentManeger.check<4)
                        {
                            AgentManeger.check++;
                        }
                        return;
                    }
                default:
                    Console.WriteLine("Invalid choice, please choose again");
                    Thread.Sleep(2000);
                    break;
            }
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
||  4. Init random sensors  ||
||  0. Exit                 ||
==============================
Enter your choice : ");
            Console.ResetColor();
            char choice = Console.ReadKey().KeyChar;
            Thread.Sleep(300);
            Console.WriteLine();            switch (choice)
            {
                case '1':
                    iraniAgent.AssignedSensorToAgenet();
                    break;
                case '2':
                    iraniAgent.CheckCompatibility();
                    break;
                case '3':
                    iraniAgent.ShowAssignedSensors();
                    break;
                case '4':
                    iraniAgent.RandomInit();
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