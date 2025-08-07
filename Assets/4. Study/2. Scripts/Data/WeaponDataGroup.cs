using System;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDataGroup", menuName = "Scriptable Objects/WeaponDataGroup")]
public class WeaponDataGroup : ScriptableObject
{
    public WData[] w_data;
}

[Serializable]
public class WData
{
    public string Name;
    public string dmg;
    public int range;
    public DetailData detail_data;
    public DamageSystem damage_sys;
}

[Serializable]
public class DetailData
{
    public int cost;
    public int upgrade_lv;
}

[Serializable]
public class DamageSystem
{
    public int min_dmg;
    public int max_dmg;
    public int accuracy_rate;
    public int critical_chance;
}
