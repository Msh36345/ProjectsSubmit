namespace Solid_Principle
{
    public class EmergencyHandler
    {
        public FileLogger file = new FileLogger();
        public EmailAlert email = new EmailAlert();

        public void HandleEmergency()
        {
            email.Send("admin@spaceagency.com",file.RetrnLog());
            Console.WriteLine("Emergency shutdown triggered!");

        }
    }
}

