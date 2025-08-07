using Pattern.Factory;
using UnityEngine;

public class GoblinFactory : MonsterFactory
{
    protected override Monster CreateMonster(string param_type)
    {
        switch (param_type)
        {
            case "Normal":
                return new GameObject("Goblin").AddComponent<Goblin>();
              
            case "Warrior":
                return new GameObject("Goblin").AddComponent<GobilnWarrior>();
             
            case "Archer":
                return new GameObject("Goblin").AddComponent<GoblinArcher>();
  
            default:
                Debug.LogError($"Unknown Monster Type : {param_type}");
                break;
        }
        return null;
    }

}