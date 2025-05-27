using OOPCommando;

class Program
{
    static void Main(string[] args)
    {
        Commando moshe = new Commando("moshe", "chiko");
        AirCommando arik = new AirCommando("arik", "aviv");
        SeaCommando izik = new SeaCommando("izik", "izo");

        Commando[] array = new Commando[3];
        array[0] = moshe;
        array[1] = arik;
        array[2] = izik;
        foreach (Commando solider in array)
        {
            solider.Attack();
        }
        



    }
}