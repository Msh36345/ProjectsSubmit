namespace OOPCommando;

public class ShootableWeapon
{
    public string Name;
    protected string Manufacturer;
    protected int CurrentAmmo;

    public ShootableWeapon(string name,string manufacturer, int currentAmmo)
    {
        Name = name;
        Manufacturer = manufacturer;
        CurrentAmmo = currentAmmo;
    }

    public void GetCurrentAmmo()
    {
        Console.WriteLine($"Current ammo in {Name} is {CurrentAmmo} bullets.");
    }
}