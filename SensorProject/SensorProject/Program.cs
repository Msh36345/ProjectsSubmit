using System;
using SensorProject;

class Program
{
    static void Main(string[] args)
    {
        AudioSensor audioSensor = new AudioSensor();
        ThermalSensor thermalSensor = new ThermalSensor();
        SensorManeger.AddSensor(audioSensor);
        SensorManeger.AddSensor(thermalSensor);
        LowLevelAgent aa = new LowLevelAgent();
        aa.AssignedSensorToAgenet();
        aa.AssignedSensorToAgenet();
        aa.Activate();


    }
}
