namespace Malshinon;

public static class Reports
{
    public static void StartReport(int idReporter)
    {
        string report = ReportText();
        string[] name = GetNameFromReport(report);
        int idTarget =People.ChecksIfUserExists(name[0]);
        if (idTarget==0)
        {
            People.CreateTarget(name);
            idTarget =People.ChecksIfUserExists(name[0]);
        }
        IntelReports.AddReport(idTarget, report,idReporter);
        People.UpdateNumMentions(idTarget);
        People.UpdateNumReports(idReporter);
        People.UpdateAndCheckThresholds(idTarget);
        People.UpdateAndCheckThresholds(idReporter);
        Console.WriteLine("Report added successfully.");
    }
    
    static string ReportText()
    {
        Console.WriteLine("Thank you very much for coming to snitch, please type the report :");
        string Report = Console.ReadLine();
        return Report;
    }

    static string[] GetNameFromReport(string report)
    {
        string[] temp = report.Split();
        List<string> name = new List<string>();
        foreach (string word in temp)
        {
            if (char.IsUpper(word[0]))
            {
                name.Add(word.ToLower());
            }

            if (char.IsLower(word[0]) && name.Count>0)
            {
                break;
            }
        }
        return name.ToArray();
    }
}