namespace OOPCommando;

public class EnemyFactory
{
    private List<Enemy> enemys;

    public EnemyFactory()
    {
        enemys = new List<Enemy>();
    }

    void AddEnemy(string name)
    {
        enemys.Add(new Enemy(name));
    }
}