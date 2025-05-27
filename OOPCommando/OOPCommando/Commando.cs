namespace OOPCommando;

public class Commando
{
    private string Name;
    public string CodeName { get; set; }
    public string[] equipment = { "Hammer", "Chisel", "Rope", "Bag", "Canteen" };
    public string status;

    public Commando(string name , string codeName)
    {
        Name = name;
        CodeName = codeName;
    }

    public void Walk()
    {
        status = "Walk";
        Console.WriteLine($"{CodeName} is walking.");
    }
    public void Hide()
    {
        status = "Hide";
        Console.WriteLine($"{CodeName} is hideing.");
    }

    public virtual void Attack()
    {
        status = "attack";
        Console.WriteLine($"💥{CodeName} is attacking.");
        
    }

    public string SayName(string commanderRank)
    {
        if (commanderRank.ToUpper().Equals("GENERAL"))
        {
            return Name;
        }

        if (commanderRank.ToUpper().Equals("COLONEL"))
        {
            return CodeName;
        }
        else
        {
            return "The soldier’s name is classified";
        }
    }
}