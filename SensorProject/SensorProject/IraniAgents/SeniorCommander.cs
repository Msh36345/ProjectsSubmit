namespace SensorProject;

public class SeniorCommander : IraniAgent
{
    public SeniorCommander()
    {
        Rank = "Senior Commander";
        Id = AgentManeger.GetId();
        AssignedSensors = new Sensor[6];
        ExposedSensors = SensorManeger.InitSensors(7,6);
        Status = "Under Investigation";
        Counter = 0;
        Attack = true;
        CounterAttack = 3;
        SensorsToDelete = 2;
        AvilableSensors = 7;

    }
}