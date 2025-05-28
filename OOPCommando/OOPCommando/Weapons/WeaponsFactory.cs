namespace OOPCommando;

public class WeaponsFactory
{
    private Dictionary<Type,List<ShootableWeapon>> shootableWeapons;
    private Dictionary<Type, List<NonShootableWeapon>> nonShootableWeapons;

    public WeaponsFactory()
    {
        shootableWeapons = new Dictionary<Type,List<ShootableWeapon>>();
        nonShootableWeapons = new Dictionary<Type, List<NonShootableWeapon>>();
    }
    
    /// <summary>
/// Add a new shootable weapone
/// 1. M16
/// 2. AK47
/// </summary>
/// <param name="type">Whitch shootable weapon</param>
    public void AddShootableWeapon(int selectWeapon)
    {
        ShootableWeapon weapon = CreateShootablleWeapon(selectWeapon);
        if (shootableWeapons.ContainsKey(weapon.GetType()))
        {
            shootableWeapons[weapon.GetType()].Add(weapon);
        }
        else
        {
            shootableWeapons[weapon.GetType()] = new List<ShootableWeapon>{weapon};
        }
    }

    ShootableWeapon CreateShootablleWeapon(int selectWeapon)
    {
        ShootableWeapon weapon = null;
        switch (selectWeapon)
        {case 1 :
                weapon = new M16();
                break;
            case 2 :
                weapon = new AK47();
                break;
        }
        return weapon;
    } 
    
    /// <summary>
    /// Add a new Non shootable weapone
    /// 1. Knife
    /// 2. Stone
    /// </summary>
    /// <param name="type">Whitch non shootable weapon</param>
    public void AddNonShootableWeapon(int selectWeapon)
    {
        NonShootableWeapon weapon = CreateNonShootablleWeapon(selectWeapon);
        if (nonShootableWeapons.ContainsKey(weapon.GetType()))
        {
            nonShootableWeapons[weapon.GetType()].Add(weapon);
        }
        else
        {
            nonShootableWeapons[weapon.GetType()] = new List<NonShootableWeapon>{weapon};
        }
    }
    NonShootableWeapon CreateNonShootablleWeapon(int selectWeapon)
    {
        NonShootableWeapon weapon = null;
        switch (selectWeapon)
        {case 1 :
                weapon = new Knife();
                break;
            case 2 :
                weapon = new Stone();
                break;
        }
        return weapon;
    }
}