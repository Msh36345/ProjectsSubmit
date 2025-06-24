namespace SensorProject;

public class SquadLeader : IraniAgent
{
    public SquadLeader()
    {
        Rank = "Squad Leader";
        Id = AgentManeger.GetId();
        AssignedSensors = new Sensor[4];
        ExposedSensors = SensorManeger.InitSensors(5,4);
        Status = "Under Investigation";
        Counter = 0;
        Attack = true;
        CounterAttack = 3;
        SensorsToDelete = 1;
        AvilableSensors = 5;

    }
}