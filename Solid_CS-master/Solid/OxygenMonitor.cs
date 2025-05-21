using System.Security.Cryptography;

namespace Solid_Principle
{
    public class OxygenMonitor
    {
        public OxygenSensor _oxygenSensor;
        public EmergencyHandler emergency = new EmergencyHandler();

        public OxygenMonitor()
        {
            _oxygenSensor = new OxygenSensor();
        }
        public void CheckOxygen()
        {
            if (_oxygenSensor.ReadLevel() < 75)
            {
                 emergency.HandleEmergency();
            }
            else
            {
                Console.WriteLine("Normal oxygen level");
            }
        }
    }
}