namespace SensorProject;

public class ThermalSensor : Sensor
{

    public ThermalSensor()
    {
        Type = "Thermal Sensor";
        Counter = 0;
        CounterFragile = 0;
        Fragile = false;
        Status = true;
    }
}