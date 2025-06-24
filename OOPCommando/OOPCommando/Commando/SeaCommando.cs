namespace OOPCommando;

public class SeaCommando : Commando
{
    public SeaCommando(string name, string codeName) : base(name, codeName){ }

    public void ReadyToSwim()
    {
        Console.WriteLine($"{CodeName} is ready to swim.");
    }
    public override void Attack()
    {
        status = "attack";
        Console.WriteLine($"💥{CodeName} is attacking from the sea.");
        
    }
}