using Pattern.Factory;
using UnityEngine;

public abstract class MonsterFactory : MonoBehaviour
{
    public Monster SpawnMonster(string param_type)
    {
        Monster monster = CreateMonster(param_type);
        return monster;
    }

    protected abstract Monster CreateMonster(string param_type);

}