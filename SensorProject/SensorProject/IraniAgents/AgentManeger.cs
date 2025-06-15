namespace SensorProject;

public static class AgentManeger
{
    private static List<IraniAgent> agents = new List<IraniAgent>();

    public static int GetId()
    {
        return agents.Count + 1;
    }
}