namespace OOPCommando;

public class Stone : NonShootableWeapon,IBreakable
{
    private int MaxHits;
    private int CurentHits;
    public Stone() : base("Stone", 1.2, "Grey", true)
    {
        MaxHits = 5;
        CurentHits = 0;
    }

    public void Hit()
    {
        if (Status)
        {
            CurentHits += 1;
            Console.Write($"{Name} thrown 🪨🪨🪨");
            ChekAndUpdateStatus();
        }
        else
        {
            Console.WriteLine("The stone is broken, cannot be hit.");
        }
    }

    private void ChekAndUpdateStatus()
    {
        if (CurentHits==MaxHits)
        {
            Status = false;
            Console.WriteLine($" and now is broken 💥");
        }
        else
        {
            Console.WriteLine($", Left hits : {MaxHits-CurentHits}");
        }
    }

    public bool GetStatus()
    {
        return Status;
    }

    public int GetMaxHits()
    {
        return MaxHits;
    }

    public int GetCurentHits()
    {
        return CurentHits;
    }
}