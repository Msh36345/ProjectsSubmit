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
            arraySensors[i] = sensors[rnd.Next(sensors.Count)];
        }

        foreach (Sensor sensor in arraySensors)
        {
            Console.WriteLine(sensor.ToString());
        }
        return arraySensors;
    }

    public static void AddSensor(Sensor sensor)
    {
        sensors.Add(sensor);
    }
    
    public static void PrintSensors()
    {
        int counter = 1;
        foreach (Sensor sensor in sensors)
        {
            Console.Write($"{counter}. {sensor.ToString()}. ");
            counter++;
        }
        Console.WriteLine();
    }

    public static void Start()
    {
        AddSensor(new AudioSensor());
        AddSensor(new ThermalSensor());
    }
}