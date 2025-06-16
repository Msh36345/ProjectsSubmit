namespace SensorProject;

public class AudioSensor : Sensor
{
    protected override string Type { get; set; }

    public AudioSensor()
    {
        Type = "Audio Sensor";
    }
    public override bool Equals(object? obj)
    {
        if (obj.GetType().Name != "AudioSensor")
        {
            return false;
        }
        AudioSensor s = (AudioSensor)obj;
        return this.Type==s.Type ;    }
}