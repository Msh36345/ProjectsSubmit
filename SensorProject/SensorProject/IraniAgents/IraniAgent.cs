namespace SensorProject;

public abstract class IraniAgent
{
    protected virtual string Rank { get; set; }
    protected virtual int Id { get; set; }
    protected virtual int Counter { get; set; }
    protected virtual bool Attack { get; set; }
    protected virtual int CounterAttack { get; set; }
    protected virtual int SensorsToDelete { get; set; }
    protected virtual string Status { get; set; }
    protected virtual Sensor[] ExposedSensors { get; set; }
    protected virtual Sensor[] AssignedSensors { get; set; }
    protected virtual int AvilableSensors { get; set; }

    public virtual void CheckCompatibility()
    {
        Activet();
        List<string> assignedString = new List<string>();
        List<string> exposedString = new List<string>();
        foreach (Sensor sensor in AssignedSensors)
        {
            if (sensor != null)
            {
                assignedString.Add(sensor.ToString());
            }
        }
        foreach (Sensor sensor in ExposedSensors)
        {
            exposedString.Add(sensor.ToString());
        }
        int mach = 0;
        foreach (string sensor in assignedString)
        {
            if (exposedString.Contains(sensor))
            {
                exposedString.Remove(sensor);
                Benefits(sensor);
                mach++;
            }
        }
        if (mach == ExposedSensors.Length)
        {
            Console.WriteLine("You cracked the exact sensors !!!");
            ChangeStatusToCompleted();
        }
        else
        {
            Console.WriteLine($"Mach : {mach}/{ExposedSensors.Length}");
        }
    }
    
    
    public virtual void AssignedSensorToAgenet()
    {
        int sensor = SelectSensorToAssigned();
        int place = SelectPlaceToAssigned();
        AssignedSensors[place] = SensorManeger.sensors[sensor];
        Log.AddLog($"ID : {Id} ,{SensorManeger.sensors[sensor].ToString()} assigned in place {place + 1}");
foreach (Sensor sensorr in AssignedSensors)
{
    if (sensorr != null)
        Console.Write(sensorr.ToString() + " ");
    else
        Console.Write("null ");
}

        ;
    }
    

    protected virtual int SelectSensorToAssigned()
    {
        SensorManeger.PrintSensors(AvilableSensors);
        Console.Write($"Select sensor : ");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        Console.WriteLine();
        string inputSensor = keyInfo.KeyChar.ToString();
        int choiceSensor = 0;
        while (!(int.TryParse(inputSensor, out choiceSensor) && choiceSensor > 0 &&
                 choiceSensor <= SensorManeger.sensors.Count))
        {
            Console.Write("Invalid input, enter a valid number : ");
            keyInfo = Console.ReadKey();
            Console.WriteLine();
            inputSensor = keyInfo.KeyChar.ToString();
        }

        return choiceSensor - 1;
    }

    protected virtual int SelectPlaceToAssigned()
    {
        Console.Write($"Select place to add/change a sensor (1-{ExposedSensors.Length}) : ");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        Console.WriteLine();
        string inputPlace = keyInfo.KeyChar.ToString();        int choicePlace = 0;
        while (!(int.TryParse(inputPlace, out choicePlace) && choicePlace > 0 && choicePlace <= ExposedSensors.Length))
        {
            Console.Write("Invalid input, enter a valid number : ");
            keyInfo = Console.ReadKey();
            Console.WriteLine();
            inputPlace = keyInfo.KeyChar.ToString();        }

        return choicePlace - 1;
    }

    public virtual void ToString()
    {
        Console.Write($"ID : {Id} || Rank : {Rank} || Sensors : {Status}");
        Console.WriteLine();
    }

    public virtual void ShowAssignedSensors()
    {

        for (int i = 0; i < AssignedSensors.Length; i++)
        {
            if (AssignedSensors[i] == null)
            {
                Console.WriteLine($"{i + 1}. null.");
            }
            else
            {
                Console.WriteLine($"{i + 1}. {AssignedSensors[i].ToString()}");
            }
        }
    }

    protected virtual void ChangeStatusToCompleted()
    {
        Status = "Investigation Completed";
    }

    private void Activet()
    {
        Counter++;
        Console.WriteLine(Counter);
        if (Attack)
        {
            if (Counter%CounterAttack==0)
            {
                for (int i = 0; i < SensorsToDelete; i++)
                {
                    AssignedSensors[AgentManeger.Random(AssignedSensors.Length)]=null;
                    Console.WriteLine("A sensor has been deleted!!!");
                }
            }
            if (Rank == "Organization Leader" && Counter % 10 == 0)
            {
                ExposedSensors = SensorManeger.InitSensors(7, 8);
                Console.WriteLine("The sensors have been changed!!!");
            }
        } 
        foreach (Sensor sensor in AssignedSensors) 
        { 
            if (sensor != null) 
            { 
                sensor.SensorActivet(); 
            } 
        }
    }

    protected virtual void Benefits(string sensor)
    { 
        if (sensor == "Magnetic Sensor") 
        {
            Counter = 0;
        }
        if (sensor == "Signal Sensor")
        {
            Console.WriteLine($"Benefits : Counter is {Counter}.");
        }
        if (sensor == "Light Sensor")
        {
            Console.WriteLine($"Benefits : One Sensor is {ExposedSensors[AgentManeger.Random(ExposedSensors.Length)]}.");
        }
    }

    public virtual void RandomInit()
    {
        AssignedSensors = SensorManeger.InitSensors(AvilableSensors, ExposedSensors.Length);
        ShowAssignedSensors();
    }
}