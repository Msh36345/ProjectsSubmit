namespace SensorProject;

public static class AgentManeger
{
    private static List<IraniAgent> agents = new List<IraniAgent>();

    public static int GetId()
    {
        return agents.Count + 1;
    }

    public static void AddAgent(IraniAgent iraniAgent)
    {
        agents.Add(iraniAgent);
        Log.AddLog($"{iraniAgent} Add to agent list");
    }

    public static void PrintAllAgent()
    {
        foreach (IraniAgent iraniAgent in agents)
        {
            iraniAgent.ToString();
        }
    }

    public static IraniAgent SelectAgent()
    {
        if (agents.Count == 0)
        {
            Console.WriteLine("No agents exist yet.");
            return null;
        }
        else
        {
            Console.WriteLine("Choice  ID agent to ");
            PrintAllAgent();
            Console.Write($"Select agent ID to investigate (1-{agents.Count}) : ");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.WriteLine();
            string inputAgent = keyInfo.KeyChar.ToString();
            int choiceAgent = 0;
            while (!(int.TryParse(inputAgent, out choiceAgent) && choiceAgent > 0 && choiceAgent <= agents.Count))
            {
                Console.Write("Invalid input, enter a valid number : ");
                keyInfo = Console.ReadKey();
                Console.WriteLine();
                inputAgent = keyInfo.KeyChar.ToString();
            }
            return agents[choiceAgent - 1];
        }
    }
}