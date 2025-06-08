using System;
using EagleEye;

class Program
{
    static void Main(string[] args)
    {
        // CreateAndAdd.CreateTable("agents",6,"eagleEyeDB");

        AgentDal agentDal = new AgentDal();
        Agent agent1 = new Agent(0,"momo","shlomo","haifa","active",3);
        agentDal.AddAgent(agent1);
        Agent agent2 = new Agent(0,"avi","avraham","ashdod","injured",15);
        agentDal.AddAgent(agent2);

        Console.WriteLine("print agents after adding");
        List<Agent> list = agentDal.GatAllAgents();
        foreach (Agent agent in list)
        {
            Console.WriteLine(agent.ToString());
        }

        Console.WriteLine("update id 1 location");
        agentDal.UpdateAgentLocition(1,"tel aviv");
        
        Console.WriteLine("print agents after edit");
        agentDal.PrintAllAgent();
        
        Console.WriteLine("delete id 2");
        agentDal.DeleteAgent(2);
        
        Console.WriteLine("print agents after deleteing");
        agentDal.PrintAllAgent();
        
        

    }
}