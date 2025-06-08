namespace EagleEye;

public class Agent
{
    private int Id;
    private string CodeName;
    private string RealName;
    private string Location;
    private string Status;
    private int MissionsCompleted;

    public Agent(int id, string codeName, string realName, string location, string status, int missionsCompleted)
    {
        Id = id;
        CodeName = codeName;
        RealName = realName;
        Location = location;
        Status = SetStatus(status);
        MissionsCompleted = missionsCompleted;
    }
    

    string SetStatus(string status)
    {
        string[] validStatuses = { "active", "injured", "missing", "retired" };
        if (validStatuses.Contains(status.ToLower()))
        {
            return status;
        }
        Console.WriteLine("Status incorrect");
        return "unknown";
    }
    public string ToAdd()
    {
        return $"'{CodeName}','{RealName}','{Location}','{Status}',{MissionsCompleted}";
    }
    
    public string ToString()
    {
        return $"Agent ID: {Id}, Code Name: {CodeName}, Real Name: {RealName}, Location: {Location}, Status: {Status}, Missions Completed: {MissionsCompleted}";
    }
}