namespace SensorProject;

public class MotionSensor : Sensor
{
    public MotionSensor()
    {
        Type = "Motion Sensor";
        Counter = 0;
        CounterFragile = 3;
        Fragile = true;
        Status = true;
    }
}