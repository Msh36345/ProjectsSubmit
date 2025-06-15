namespace SensorProject;

public class ThermalSensor : Sensor
{
    protected override string Type { get; set; }

    public ThermalSensor()
    {
        Type = "Thermal Sensor";
    }
}