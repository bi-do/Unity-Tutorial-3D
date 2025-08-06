using System.Collections;
using UnityEngine;

public class MoveState : MonoBehaviour ,IState
{
    public void StateEnter()
    {
        Debug.Log("MoveEnter");
    }


    public void StateExit()
    {
        Debug.Log("MoveExit");
    }



    public void StateUpdate()
    {
        Debug.Log("Move");
    }

    IEnumerator MethodA()
    {
        yield return new WaitForSeconds(0);
    }
}