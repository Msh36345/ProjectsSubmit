namespace SensorProject;

public abstract class Sensor
{
    protected virtual string Type { get; set; }
    protected virtual int Counter { get; set; }
    protected virtual bool Fragile { get; set; }
    protected virtual int CounterFragile { get; set; }
    public virtual bool Status { get; protected set; }


    public virtual string ToString()
    {
        return Type;
    }

    public virtual void SensorActivet()
    {
        if (Fragile)
        {
            if (Counter % CounterFragile == 0)
            {
                Status = false;
            }
            Counter++;
        }
    }
    
}