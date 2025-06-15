namespace SensorProject;

public abstract class IraniAgent
{
    protected abstract string Rank { get; set; }
    protected abstract int Id { get; set; }
    protected abstract Sensor[] ExposedSensors { get; set; }
    protected abstract Sensor[] AssignedSensors { get; set; }

    public virtual void Activate()
    {
        List<Sensor> assigned = new List<Sensor>(AssignedSensors);
        int counter = 0;
        foreach (Sensor esensor in ExposedSensors)
        {
            foreach (Sensor asensor in assigned)
            {
                if (esensor==asensor)
                {
                    counter++;
                    assigned.Remove(asensor);
                }
            }
        }

        Console.WriteLine($"{counter}/{ExposedSensors.Length}");
    }
}