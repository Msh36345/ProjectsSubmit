namespace SensorProject;

public class SignalSensor : Sensor
{
    public SignalSensor()
    {
        Type = "Signal Sensor";
        Counter = 0;
        CounterFragile = 3;
        Fragile = true;
        Status = true;
    }
}