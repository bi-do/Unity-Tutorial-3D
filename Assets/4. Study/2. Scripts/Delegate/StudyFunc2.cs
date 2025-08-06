using System;
using System.Collections.Generic;
using UnityEngine;

public class StudyFunc2 : MonoBehaviour
{
    public Func<int, int, int> my_func;
    public List<Func<int, int, int>> func_lis = new List<Func<int, int, int>>();


    void Start()
    {
        func_lis.Add((int a, int b) => a + b);
        func_lis.Add((int a, int b) => a - b);
        func_lis.Add((int a, int b) => a * b);

        foreach (Func<int, int, int> element in func_lis)
        {
            Debug.Log(element?.Invoke(10, 10));
        }
    }

}