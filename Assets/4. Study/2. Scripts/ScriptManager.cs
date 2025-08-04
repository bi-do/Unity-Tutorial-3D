using System;
using UnityEngine;

public class ScriptManager : MonoBehaviour
{
    public static Action emergency_stop_btn;

    void Start()
    {
        if (emergency_stop_btn == null)
            emergency_stop_btn += StopMSG;
    }

    private void StopMSG()
    {
        Debug.Log("긴급 정지 실행");
    }

    public void MethodA()
    {

    }

    public void MethodB()
    {

    }

}

