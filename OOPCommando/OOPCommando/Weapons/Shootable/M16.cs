namespace OOPCommando;

public class M16 : ShootableWeapon, IShootable
{
    public M16() : base("M16", "Colt", 29){}

    public void GetCurrentAmmo()
    {
        Console.WriteLine($"Current ammo in {Name} is {CurrentAmmo} bullets.");

    }

    public void Shoot()
    {
        if (CurrentAmmo == 0)
        {
            Console.WriteLine("Magazine is empty, cannot shoot.");
        }
        else
        {
            CurrentAmmo -= 1;
            Console.WriteLine($"{Name} Shoot 🔫🔫🔫 ,Current ammo : {CurrentAmmo}.");
        }

    }
}