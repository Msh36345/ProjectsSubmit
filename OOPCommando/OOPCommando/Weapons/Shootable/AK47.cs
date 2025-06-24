namespace OOPCommando;

public class AK47 : ShootableWeapon, IShootable
{
    public AK47() : base("AK47", "Kalashnikov", 30){}

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