namespace SensorProject;

public abstract class IraniAgent
{
    protected abstract string Rank { get; set; }
    protected abstract int Id { get; set; }
    protected abstract Sensor[] ExposedSensors { get; set; }
    protected abstract Sensor[] AssignedSensors { get; set; }

    // public virtual void Activate()
    // {
    //     List<Sensor> assigned = new List<Sensor>(AssignedSensors);
    //     int counter = 0;
    //     Sensor s = null;
    //     foreach (Sensor esensor in ExposedSensors)
    //     {
    //         foreach (Sensor asensor in assigned)
    //         {
    //             if (esensor.Equals(asensor))
    //             {
    //                 counter++;
    //                 s = asensor;
    //             }
    //         }
    //     }
    //     if (s != null)
    //     {
    //         assigned.Remove(s);
    //     }
    //
    //     Console.WriteLine($"{counter}/{ExposedSensors.Length}");
    // }

    public virtual void Activate()
    {
        List<Sensor> assigned = new List<Sensor>(AssignedSensors);
        List<int> indexs = new List<int>();
        foreach (Sensor esensor in ExposedSensors)
        {
            foreach (Sensor asensor in AssignedSensors)
            {
                if (esensor==asensor)
                {
                    indexs.Add(assigned.IndexOf(asensor));
                }
            }
        }
        if (indexs.Count > 0)
        {
            indexs = indexs.Distinct().ToList();
        }
        Console.WriteLine($"{indexs.Count}/{ExposedSensors.Length}");
    }

    public virtual void AssignedSensorToAgenet()
    {
        int sensor = SelectSensorToAssigned();
        int place = SelectPlaceToAssigned();
        AssignedSensors[place] = SensorManeger.sensors[sensor];
        Log.AddLog($"ID : {Id} ,{SensorManeger.sensors[sensor].ToString()} assigned in place {place+1}");
    }

    protected virtual int SelectSensorToAssigned()
    {
        SensorManeger.PrintSensors();
        Console.Write($"Select sensor (1-{SensorManeger.sensors.Count}) : ");
        string inputSensor = Console.ReadLine();
        int choiceSensor = 0;
        while (!(int.TryParse(inputSensor, out choiceSensor) && choiceSensor > 0 && choiceSensor <= SensorManeger.sensors.Count))
        {
            Console.Write("Invalid input, enter a valid number : ");
            inputSensor = Console.ReadLine();
        }

        return choiceSensor - 1;
    }

    protected virtual int SelectPlaceToAssigned()
    {
        Console.Write($"Select place to add/change a sensor (1-{ExposedSensors.Length}) : ");
        string inputPlace = Console.ReadLine();
        int choicePlace = 0;
        while (!(int.TryParse(inputPlace, out choicePlace) && choicePlace > 0 && choicePlace <= ExposedSensors.Length))
        {
            Console.Write("Invalid input, enter a valid number : ");
            inputPlace = Console.ReadLine();
        }
        return choicePlace - 1;
    }
}