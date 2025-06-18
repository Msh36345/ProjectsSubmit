namespace SensorProject;

public class AudioSensor : Sensor
{

    public AudioSensor()
    {
        Type = "Audio Sensor";
        Counter = 0;
        CounterFragile = 0.5;
        Fragile = false;
        Status = true;
    }
}