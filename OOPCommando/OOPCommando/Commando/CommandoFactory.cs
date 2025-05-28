namespace OOPCommando;

public class CommandoFactory
{
    private Dictionary<Type,List<Commando>> commandos;

    public CommandoFactory()
    {
        commandos = new Dictionary<Type,List<Commando>>();
    }

    public void AddSolider(string name, string codeName, int type)
    {
        Commando solider = CreateSolider(name,codeName,type);
        if (commandos.ContainsKey(solider.GetType()))
        {
            commandos[solider.GetType()].Add(solider);
        }
        else
        {
            commandos[solider.GetType()] = new List<Commando>{solider};
        }
    }

    Commando CreateSolider(string name, string codeName, int type)
    {
        Commando solider = null;
        switch (type)
        {case 1 :
            solider = new Commando(name, codeName);
        break;
        case 2 :
            solider = new AirCommando(name, codeName);
        break;
        case 3 :
            solider = new SeaCommando(name, codeName);
        break;
        }
        return solider;
    }
}