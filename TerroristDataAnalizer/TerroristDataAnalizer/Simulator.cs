using System.Text.Json;
using System.IO;
namespace TerroristDataAnalizer;

public class Simulator
{
    public List<Dictionary<string, object>> GenerateTerroristData()
    {
        var terrorists = new List<Dictionary<string, object>>();
        string[] firstNames = {
            "Ahmad", "Yousef", "Saeed", "Khaled", "Rami",
            "Maher", "Fadi", "Basem", "Nader", "Alaa",
            "Hussein", "Ali", "Wasim", "Mahmoud", "Ibrahim",
            "Tariq", "Jihad", "Samir", "Ammar", "Sharif"
        };
        string[] lastNames = {
            "Khalil", "Mansour", "Al-Ali", "Zeidan", "Yousef",
            "Salim", "Darwish", "Radi", "Jaber", "Naim",
            "Barakat", "Omran", "Al-Zahar", "Hijazi", "Kamal",
            "Najm", "Shaaban", "Maqdad", "Abu-Salim", "Qasem"
        };
        string[] weapons = { "Knife", "M16", "Handgun" };
        string[] affiliations = { "Hamas", "Islamic Jihad" };
        Random rand = new Random();
        
        for (int i = 0; i < 20; i++)
        {
            var person = new Dictionary<string, object>();
            person["name"] = firstNames[rand.Next(firstNames.Length)] + " " +
                             lastNames[rand.Next(lastNames.Length)];
            person["weapons"] = GetRandomWeapons(rand, weapons);
            person["age"] = rand.Next(18, 51);
            var location = (
                Math.Round(rand.NextDouble() * 180 - 90, 2),
                Math.Round(rand.NextDouble() * 360 - 180, 2)
            );
            person["lastLocation"] = new Dictionary<string, string> {
                { "lat", location.Item1.ToString("F2") },
                { "lon", location.Item2.ToString("F2") }
            };
            person["affiliation"] = affiliations[rand.Next(affiliations.Length)];
            terrorists.Add(person);
        }

        return terrorists;
    }

    private static List<string> GetRandomWeapons(Random rand, string[] weapons)
    {
        var list = new List<string>();
        foreach (var weapon in weapons)
        {
            if (rand.NextDouble() < 0.5) // 50% chance to include each weapon
                list.Add(weapon);
        }
        if (list.Count == 0)
            list.Add(weapons[rand.Next(weapons.Length)]); // ensure at least one weapon
        return list;
    }
}