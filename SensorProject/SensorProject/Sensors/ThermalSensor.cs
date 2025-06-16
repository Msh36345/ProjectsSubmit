namespace SensorProject;

public class ThermalSensor : Sensor
{
    protected override string Type { get; set; }

    public ThermalSensor()
    {
        Type = "Thermal Sensor";
    }
    public override bool Equals(object? obj)
    {
        if (obj.GetType().Name != "ThermalSensor")
        {
            return false;
        }
        ThermalSensor s = (ThermalSensor)obj;
        return this.Type==s.Type ;    }
}