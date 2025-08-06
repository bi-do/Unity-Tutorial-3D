using UnityEngine;

public class AttackState :  MonoBehaviour , IState
{
    public void StateEnter()
    {
        Debug.Log("AttackEnter");
    }

    public void StateExit()
    {
         Debug.Log("AttackExit");
    }

    public void StateUpdate()
    {
        Debug.Log("Attack");
    }
}