using UnityEngine;

public class IdleState :  MonoBehaviour , IState
{

    public void StateEnter()
    {
        Debug.Log("IdleEnter");
    }

    public void StateExit()
    {
         Debug.Log("IdleExit");
    }

    public void StateUpdate()
    {
        Debug.Log("Idle");
    }
}