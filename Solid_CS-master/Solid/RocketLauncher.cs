using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Principle
{
    internal class RocketLauncher
    {
        public OxygenMonitor monitor = new OxygenMonitor();
        public void LaunchRocket()
        {
            Console.WriteLine("Rocket launched!");
            monitor.CheckOxygen();
        }
        
    }
}