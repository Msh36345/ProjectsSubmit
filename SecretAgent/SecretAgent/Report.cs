namespace SecretAgent;

public class Report
{
    public string Summary;
    public int UrgencyLevel;
    public Agent SubmittedBy;

    public Report(string summary, int urgencyLevel, Agent submittedBy)
    {
        Summary = summary;
        UrgencyLevel = urgencyLevel;
        SubmittedBy = submittedBy;
    }
}