namespace SecretAgent;

public static class IntelTools
{
    public static string EncryptMessage(string message)
    {
        string encryptMessage = "";
        for (int i = message.Length - 1; i >= 0; i--)
        {
            encryptMessage += message[i];
        }
        return encryptMessage;
    }

    public static void LogTransmission(string agentName, string message)
    {
        Console.WriteLine($"{agentName} sent encrypted message: {message}");
    }
}