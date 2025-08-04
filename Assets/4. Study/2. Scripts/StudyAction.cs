using System;
using UnityEngine;

public class StudyAction : MonoBehaviour
{
    public delegate void Mydelegate();

    public Action action;
    public Action<int> action2;

    void Start()
    {
        action += () => Debug.LogFormat("Action");

        action.Invoke();
    }
}