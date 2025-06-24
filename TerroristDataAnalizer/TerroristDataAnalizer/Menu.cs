using TerroristDataAnalizer;

static class Menu
{
    public static void Start()
    {
        Simulator simulator = new Simulator();
        var terrorists = simulator.GenerateTerroristData();

        while (true)
        {
            Console.WriteLine("\n=== Terrorist Data Analyzer Menu ===");
            Console.WriteLine("1. Most common weapon");
            Console.WriteLine("2. Least common weapon");
            Console.WriteLine("3. Organization with most members");
            Console.WriteLine("4. Organization with least members");
            Console.WriteLine("5. Closest two terrorists");
            Console.WriteLine("0. Exit");
            Console.Write("Choose option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Analyze.MostCommonWeapon(terrorists);
                    break;
                case "2":
                    Analyze.LeastCommonWeapon(terrorists);
                    break;
                case "3":
                    Analyze.MostCommonAffiliation(terrorists);
                    break;
                case "4":
                    Analyze.LeastCommonAffiliation(terrorists);
                    break;
                case "5":
                    Analyze.ClosestTerrorists(terrorists);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}