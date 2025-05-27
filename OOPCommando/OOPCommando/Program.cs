using OOPCommando;

class Program
{
    static void Main(string[] args)
    {
        Commando moshe = new Commando("moshe", "chiko");
        Commando shlomo = new Commando("shlomo", "momo");
        moshe.Attack();
        moshe.Hide();
        moshe.Walk();
        Weapon uzi = new Weapon("uzi", "refael", 15);
        uzi.Shoot();
    }
}