namespace SecretAgent;

public class MissionControl
{
    public static void AnalyzeReport(Report report)
    {
        if (report.UrgencyLevel >= 4)
            Console.WriteLine("Immediate response required.");
        else if (report.UrgencyLevel == 3)
            Console.WriteLine("High priority. Monitor closely.");
        else
            Console.WriteLine("Routine analysis.");
    }
}