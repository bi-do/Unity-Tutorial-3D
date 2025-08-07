using Pattern.Factory;
using UnityEngine;

public class OrcFactory : MonsterFactory
{
    protected override Monster CreateMonster(string param_type)
    {
        switch (param_type)
        {
            case "Normal":
                return new GameObject("Orc").AddComponent<Orc>();

            case "Warrior":
                return new GameObject("Orc Warrior").AddComponent<OrcWarrior>();

            case "Archer":
                return new GameObject("Orc Archer").AddComponent<OrcArcher>();

            default:
                Debug.LogError($"Unknown Monster Type : {param_type}");
                break;
        }
        return null;
    }
}