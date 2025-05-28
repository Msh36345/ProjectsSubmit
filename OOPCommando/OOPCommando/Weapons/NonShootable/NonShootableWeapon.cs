namespace OOPCommando;

public class NonShootableWeapon
{
    protected string Name;
    protected double Weight;
    protected string Color;
    protected bool Status;

    public NonShootableWeapon(string name, double weight, string color, bool status)
    {
        Name = name;
        Weight = weight;
        Color = color;
        Status = status;
    }
}