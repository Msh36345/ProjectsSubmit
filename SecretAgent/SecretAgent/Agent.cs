namespace SecretAgent;

public class Agent
{
    private string CodeName;
    private int ClearanceLevel;

    public Agent(string codeName, int clearanceLevel)
    {
        CodeName = codeName;
        ClearanceLevel = clearanceLevel;
    }

    public void Report()
    {
        Console.WriteLine($"Agent {CodeName} reporting. Clearance Level: {ClearanceLevel}");
    }
    public string GetCodeName()
    {
        return CodeName;
    }
    public int GetClearanceLevel()
    {
        return ClearanceLevel;
    }

    public void SetClearanceLevel(int level)
    {
        if (level >= 1 && level <= 5)
        {
            ClearanceLevel = level;
        }
        else
        {
            Console.WriteLine("Clearance level must be between 1 and 5.");
        }
    }
}