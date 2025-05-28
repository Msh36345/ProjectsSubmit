namespace OOPCommando;

public class AirCommando : Commando
{
    public AirCommando(string name, string codeName) : base(name, codeName){ }

    public void ReadyToJump()
    {
        Console.WriteLine($"{CodeName} is ready to jump.");
    }
    public override void Attack()
    {
        status = "attack";
        Console.WriteLine($"💥{CodeName} is attacking from the air.");
        
    }
}