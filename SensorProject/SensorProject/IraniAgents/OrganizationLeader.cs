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
}