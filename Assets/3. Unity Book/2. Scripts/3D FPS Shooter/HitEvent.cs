using UnityEngine;

public class HitEvent : MonoBehaviour
{
    public EnemyFSM efsm;
    void PlayerHit()
    {
        efsm.AttackAction();
    }
}
