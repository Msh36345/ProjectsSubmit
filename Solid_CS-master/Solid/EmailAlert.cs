namespace Solid_Principle;

public class EmailAlert : IEmailAlert
{
    public void Send(string to, string message)
    {
        Console.WriteLine($"Sending email to {to}: {message}");
    }

}