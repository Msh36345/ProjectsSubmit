using System;
using SensorProject;

class Program
{
    static void Main(string[] args)
    {
        SensorManeger.AddSensor(new AudioSensor());
        SensorManeger.AddSensor(new ThermalSensor());
        // LowLevelAgent aa = new LowLevelAgent();
        // aa.Activate();
        // aa.AssignedSensorToAgenet();
        // aa.AssignedSensorToAgenet();
        GameManeger.Start();

    }
}
