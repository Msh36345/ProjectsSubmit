namespace SensorProject;

public class OrganizationLeader : IraniAgent
{
    public OrganizationLeader()
    {
        Rank = "Organization Leader";
        Id = AgentManeger.GetId();
        AssignedSensors = new Sensor[8];
        ExposedSensors = SensorManeger.InitSensors(7, 8);
        Status = "Under Investigation";
        Counter = 0;
        Attack = true;
        CounterAttack = 3;
        SensorsToDelete = 2;
        AvilableSensors = 7;
    }
    
    protected override void Activet()
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
                Counter++;
            }

            if (Counter % 10 == 0)
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
}