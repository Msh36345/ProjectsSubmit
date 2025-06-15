namespace SensorProject;

public static class SensorManeger
{
    public static List<Sensor> sensors = new List<Sensor>();
    
    public static Sensor[] InitSensors(int num)
    {
        Sensor[] arraySensors = new Sensor[num];
        for (int i = 0; i < num; i++)
        {
            Random rnd = new Random();
            sensors[i] = sensors[rnd.Next(sensors.Count)];
        }
        return arraySensors;
    }
}