using System;

namespace Solid_Principle
{
    public class OxygenSensor : IOxygenSensor
    {
        public int OxygenLevel { get; set; } = 75;
        public int ReadLevel()
        {
            return OxygenLevel;
        }
        public void SetLevel(int level)
        {
            OxygenLevel = level;
        }
    }
}