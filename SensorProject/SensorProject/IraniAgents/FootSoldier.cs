namespace SensorProject;

public class FootSoldier :IraniAgent
{
    public FootSoldier()
    {
        Rank = "Foot Solider";
        Id = AgentManeger.GetId();
        AssignedSensors = new Sensor[2];
        ExposedSensors = SensorManeger.InitSensors(2,2);
        Status = "Under Investigation";
        Counter = 0;
        Attack = false;
        AvilableSensors = 2;

    }
}