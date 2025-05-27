namespace OOPCommando;

public class Commando
{
    private string Name;
    private string CodeName;
    private string[] equipment = { "Hammer", "Chisel", "Rope", "Bag", "Canteen" };
    private string status;

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

    public void Attack()
    {
        status = "attack";
        Console.WriteLine($"💥{CodeName} is attacking.");
        
    }
}