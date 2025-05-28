namespace OOPCommando;

public class WeaponsFactory
{
    private Dictionary<Type,List<ShootableWeapon>> weapons;

    public WeaponsFactory()
    {
        weapons = new Dictionary<Type,List<ShootableWeapon>>();
    }
/// <summary>
/// Add a new shootable weapone
/// 1. M16
/// 2. AK47
/// </summary>
/// <param name="type">Whitch shootable weapon</param>
    public void AddShootableWeapon(int type)
    {
        ShootableWeapon weapon = CreateWeapon(type);
        if (weapons.ContainsKey(weapon.GetType()))
        {
            weapons[weapon.GetType()].Add(weapon);
        }
        else
        {
            weapons[weapon.GetType()] = new List<ShootableWeapon>{weapon};
        }
    }

    ShootableWeapon CreateWeapon(int type)
    {
        ShootableWeapon weapon = null;
        switch (type)
        {case 1 :
                weapon = new M16();
                break;
            case 2 :
                weapon = new AK47();
                break;
        }
        return weapon;
    }

}