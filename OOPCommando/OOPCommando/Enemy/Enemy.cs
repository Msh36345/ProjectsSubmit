namespace OOPCommando;

public class Enemy
{
    public string Name;
    private int Live;
    private bool status;

    public Enemy(string name)
    {
        Name = name;
        Live = 100;
        status = true;
    }

    void Scream()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("I am an enemy!!");
        Console.ResetColor();
    }
}