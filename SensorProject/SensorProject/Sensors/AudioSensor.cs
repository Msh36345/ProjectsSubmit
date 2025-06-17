namespace SensorProject;

public class AudioSensor : Sensor
{
    protected override string Type { get; set; }

    public AudioSensor()
    {
        Type = "Audio Sensor";
    }
}