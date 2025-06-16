namespace SensorProject;

public abstract class Sensor
{
    protected abstract string Type { get; set; }

    public virtual string ToString()
    {
        return Type;
    }
    
}