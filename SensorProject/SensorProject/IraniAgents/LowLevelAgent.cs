namespace SensorProject;

public class LowLevelAgent :IraniAgent
{
    protected override string Rank { get; set; }
    protected override int Id { get; set; }
    protected override Sensor[] ExposedSensors { get; set; }
    protected override Sensor[] AssignedSensors { get; set; }

    public LowLevelAgent()
    {
        Rank = "Low Level Agent";
        Id = AgentManeger.GetId();
        AssignedSensors = new Sensor[2];
        ExposedSensors = SensorManeger.InitSensors(2);
    }
}