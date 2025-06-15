namespace SensorProject;

public abstract class IraniAgent
{
    public abstract string Rank { get; set; }
    public abstract int Id { get; set; }
    public abstract string[] ExposedSensors { get; set; }
    public abstract string[] AssignedSensors { get; set; }

    public virtual int Activate()
    {
        List<string> assigned = new List<string>(AssignedSensors);
        int counter = 0;
        foreach (string esensor in ExposedSensors)
        {
            foreach (string asensor in assigned)
            {
                if (esensor==asensor)
                {
                    counter++;
                    assigned.Remove(asensor);
                }
            }
        }
        return counter;
    }
}