namespace SecretAgent;

class Program
{
    static void Main(string[] args)
    {
        Agent agent8200 = new Agent("Shadow8200", 5);
        Report report = new Report("Suspicious movement near border", 4, agent8200);

        MissionControl.AnalyzeReport(report);

        string encrypted = IntelTools.EncryptMessage(report.Summary);
        IntelTools.LogTransmission(agent8200.GetCodeName(), encrypted);
    }
}