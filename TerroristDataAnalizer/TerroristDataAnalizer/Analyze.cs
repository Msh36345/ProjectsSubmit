namespace TerroristDataAnalizer;

public class Analyze
{
    public static void MostCommonWeapon(List<Dictionary<string, object>> terrorists)
    {
        var weaponCounts = new Dictionary<string, int>();

        foreach (var terrorist in terrorists)
        {
            var weapons = (List<string>)terrorist["weapons"];
            foreach (var weapon in weapons)
            {
                if (!weaponCounts.ContainsKey(weapon))
                    weaponCounts[weapon] = 0;
                weaponCounts[weapon]++;
            }
        }

        string mostCommonWeapon = "";
        int highestCount = 0;

        foreach (var pair in weaponCounts)
        {
            if (pair.Value > highestCount)
            {
                highestCount = pair.Value;
                mostCommonWeapon = pair.Key;
            }
        }
        Console.WriteLine($"Most common weapon: {mostCommonWeapon} ({highestCount} times)");
    }

    public static void LeastCommonWeapon(List<Dictionary<string, object>> terrorists)
    {
        var weaponCounts = new Dictionary<string, int>();

        foreach (var terrorist in terrorists)
        {
            var weapons = (List<string>)terrorist["weapons"];
            foreach (var weapon in weapons)
            {
                if (!weaponCounts.ContainsKey(weapon))
                    weaponCounts[weapon] = 0;
                weaponCounts[weapon]++;
            }
        }

        string leastCommonWeapon = "";
        int lowestCount = int.MaxValue;

        foreach (var pair in weaponCounts)
        {
            if (pair.Value < lowestCount)
            {
                lowestCount = pair.Value;
                leastCommonWeapon = pair.Key;
            }
        }
        Console.WriteLine($"Least common weapon: {leastCommonWeapon} ({lowestCount} times)");
    }

    public static void MostCommonAffiliation(List<Dictionary<string, object>> terrorists)
    {
        Dictionary<string, int> affiliationCounts = new();

        foreach (var terrorist in terrorists)
        {
            string affiliation = terrorist["affiliation"].ToString();

            if (!affiliationCounts.ContainsKey(affiliation))
                affiliationCounts[affiliation] = 0;

            affiliationCounts[affiliation]++;
        }

        string mostCommon = "";
        int mostCount = 0;

        foreach (var pair in affiliationCounts)
        {
            if (pair.Value > mostCount)
            {
                mostCommon = pair.Key;
                mostCount = pair.Value;
            }
        }

        Console.WriteLine($"Organization with most members: {mostCommon} ({mostCount} members)");
    }

    public static void LeastCommonAffiliation(List<Dictionary<string, object>> terrorists)
    {
        Dictionary<string, int> affiliationCounts = new();

        foreach (var terrorist in terrorists)
        {
            string affiliation = terrorist["affiliation"].ToString();

            if (!affiliationCounts.ContainsKey(affiliation))
                affiliationCounts[affiliation] = 0;

            affiliationCounts[affiliation]++;
        }

        string leastCommon = "";
        int leastCount = int.MaxValue;

        foreach (var pair in affiliationCounts)
        {
            if (pair.Value < leastCount)
            {
                leastCommon = pair.Key;
                leastCount = pair.Value;
            }
        }

        Console.WriteLine($"Organization with least members: {leastCommon} ({leastCount} members)");
    }

    //made in GPT
    public static void ClosestTerrorists(List<Dictionary<string, object>> terrorists)
    {
        double minDistance = double.MaxValue;
        string name1 = "", name2 = "";

        for (int i = 0; i < terrorists.Count; i++)
        {
            var loc1 = (Dictionary<string, string>)terrorists[i]["lastLocation"];
            double lat1 = double.Parse(loc1["lat"]);
            double lon1 = double.Parse(loc1["lon"]);

            for (int j = i + 1; j < terrorists.Count; j++)
            {
                var loc2 = (Dictionary<string, string>)terrorists[j]["lastLocation"];
                double lat2 = double.Parse(loc2["lat"]);
                double lon2 = double.Parse(loc2["lon"]);

                double distance = Math.Sqrt(Math.Pow(lat1 - lat2, 2) + Math.Pow(lon1 - lon2, 2));
                if (distance < minDistance)
                {
                    minDistance = distance;
                    name1 = terrorists[i]["name"].ToString();
                    name2 = terrorists[j]["name"].ToString();
                }
            }
        }

        Console.WriteLine($"Closest terrorists: {name1} and {name2} (Distance: {minDistance:F2})");
    }
}