namespace OOPCommando;

public class Game
{
    private CommandoFactory commando;
    private EnemyFactory enemy;
    private WeaponsFactory weapon;

    public Game()
    {
        commando = new CommandoFactory();
        enemy = new EnemyFactory();
        weapon = new WeaponsFactory();
    }

    public void Start()
    {
        
    }
    
}