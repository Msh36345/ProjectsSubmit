namespace SensorProject;

public class LightSensor : Sensor
{
    public LightSensor()
    {
        Type = "Light Sensor";
        Counter = 0;
        CounterFragile = 3;
        Fragile = true;
        Status = true;
    }
}