namespace SensorProject;

public class PulseSensor : Sensor
{
    public PulseSensor()
    {
        Type = "Pulse Sensor";
        Counter = 0;
        CounterFragile = 3;
        Fragile = true;
        Status = true;
    }
}