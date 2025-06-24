namespace SensorProject;

public static class SensorManeger
{
    public static List<Sensor> sensors = new List<Sensor>();
    
    public static Sensor[] InitSensors(int numSensors,int slots)
    {
        Sensor[] arraySensors = new Sensor[slots];
        for (int i = 0; i < slots; i++)
        {
            Random rnd = new Random();
            arraySensors[i] = sensors[rnd.Next(numSensors)];
        }

        // foreach (Sensor sensor in arraySensors)
        // {
        //     Console.Write(sensor.ToString()+" ");
        // }
        return arraySensors;
    }

    public static void AddSensor(Sensor sensor)
    {
        sensors.Add(sensor);
    }

    public static void PrintSensors(int length = 7)
    {
        for (int i = 0; i < length; i++)
        {
            Console.Write($"{i+1}. {sensors[i].ToString()} ");
        }
        Console.WriteLine();
    }

    public static void Start()
    {
        AddSensor(new AudioSensor());
        AddSensor(new ThermalSensor());
        AddSensor(new PulseSensor());
        AddSensor(new MotionSensor());
        AddSensor(new MagneticSensor());
        AddSensor(new SignalSensor());
        AddSensor(new LightSensor());
    }
}