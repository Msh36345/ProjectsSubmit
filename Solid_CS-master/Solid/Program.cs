using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Principle
{
    internal class Program
    {
        static void Main()
        {
            RocketLauncher apolo = new RocketLauncher();
            apolo.LaunchRocket();
            Console.WriteLine();
            apolo.monitor._oxygenSensor.SetLevel(60);
            apolo.monitor.CheckOxygen();
        }
    }
}