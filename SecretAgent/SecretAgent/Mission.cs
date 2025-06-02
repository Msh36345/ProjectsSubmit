namespace SecretAgent;

public class Mission
{
    public string MissionName;
    public string TargetLocation;
    private Agent AssignedAgent;

    public Mission(string missionName, string targetLocation)
    {
        MissionName = missionName;
        TargetLocation = targetLocation;
    }

    public void AssignAgent(Agent agent)
    {
        AssignedAgent = agent;
    }

    public void Brief()
    {
        Console.WriteLine($"Mission: {MissionName}, Target: {TargetLocation}, Agent: {AssignedAgent.GetCodeName()}");
    }
}