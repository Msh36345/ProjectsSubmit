namespace OOPCommando;

public class Weapon
{
    private string Name;
    private string Manufacturer;
    private int CurrentAmmo;

    public Weapon(string name,string manufacturer, int currentAmmo)
    {
        Name = name;
        Manufacturer = manufacturer;
        CurrentAmmo = currentAmmo;
    }

    public void Shoot()
    {
        if (CurrentAmmo==0)
        {
            Console.WriteLine("Magazine is empty, cannot shoot.");
        }
        else
        {
            CurrentAmmo -= 1;
            Console.WriteLine($"{Name} Shoot 🔫🔫🔫 ,Current ammo : {CurrentAmmo}.");
        }
    }

    public void GetCurrentAmmo()
    {
        Console.WriteLine($"Current ammo in {Name} is {CurrentAmmo} bullets.");
    }
}