using Pattern.Factory;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    MonsterFactory cur_factory = null;
    Monster cur_monster = null;

    private GoblinFactory goblin_factory = null;
    private OrcFactory orc_factory = null;


    void Awake()
    {
        this.goblin_factory = new GameObject("Goblin Factory").AddComponent<GoblinFactory>();
        this.orc_factory = new GameObject("Orc Factory").AddComponent<OrcFactory>();
    }

    void Start()
    {
        cur_factory = goblin_factory;
        cur_monster = cur_factory.SpawnMonster("Normal");
        cur_monster = cur_factory.SpawnMonster("Warrior");
        cur_monster = cur_factory.SpawnMonster("Archer");

        cur_factory = orc_factory;
        cur_monster = cur_factory.SpawnMonster("Normal");
        cur_monster = cur_factory.SpawnMonster("Warrior");
        cur_monster = cur_factory.SpawnMonster("Archer");

    }
}