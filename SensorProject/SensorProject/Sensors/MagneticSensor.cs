namespace SensorProject;

public class MagneticSensor : Sensor
{
    public MagneticSensor()
    {
        Type = "Magnetic Sensor";
        Counter = 0;
        CounterFragile = 0;
        Fragile = false;
        Status = true;
    }
}