namespace SecretAgent;

public class Agent
{
    private string codeName;
    private int clearanceLevel;

    public Agent(string codeName, int clearanceLevel)
    {
        if (string.IsNullOrWhiteSpace(codeName))
        {
            throw new ArgumentException("Code name cannot be null or empty", nameof(codeName));
        }
        
        if (clearanceLevel < 1 || clearanceLevel > 5)
        {
            throw new ArgumentException("Clearance level must be between 1 and 5", nameof(clearanceLevel));
        }

        this.codeName = codeName;
        this.clearanceLevel = clearanceLevel;
    }

    public void Report()
    {
        Console.WriteLine($"Agent {codeName} reporting. Clearance Level: {clearanceLevel}");
    }

    public string GetCodeName()
    {
        return codeName;
    }

    public int GetClearanceLevel()
    {
        return clearanceLevel;
    }

    public void SetClearanceLevel(int level)
    {
        if (level < 1 || level > 5)
        {
            throw new ArgumentException("Clearance level must be between 1 and 5", nameof(level));
        }
        clearanceLevel = level;
    }
}