namespace OOPCommando;

public class Knife : NonShootableWeapon
{
    private string Manufacturer;
    private string MetalType;
    public Knife() : base("Knife", 0.4, "Black", true)
    {
        Manufacturer = "KA-BAR";
        MetalType = "Steel";
    }

    public void Stab()
    {
        if (Status)
        {
            Console.WriteLine($"{Name} stabbed 🔪");
        }
        else
        {
            Console.WriteLine("The knife is broken, cannot stab.");
        }
    }
    
    public bool GetStatus()
    {
        return Status;
    }
}