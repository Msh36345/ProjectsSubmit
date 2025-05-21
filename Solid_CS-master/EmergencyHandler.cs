namespace Solid_Principle
    {
        public class EmergencyHandler
        {
            private readonly ILogger _logger;
            private readonly IEmailAlert _emailAlert;

            public EmergencyHandler(ILogger logger, IEmailAlert emailAlert)
            {
                _logger = logger;
                _emailAlert = emailAlert;
            }

            public void HandleEmergency()
            {
                Console.WriteLine("Emergency shutdown triggered!");
                _logger.Log("EMERGENCY OCCURRED");
                _emailAlert.SendEmail("Emergency triggered");
            }
        }
    }
    }
}
