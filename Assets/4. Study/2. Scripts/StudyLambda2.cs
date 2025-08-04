using System.Collections.Generic;
using UnityEngine;

public class StudyLambda2 : MonoBehaviour
{
    public List<int> ints = new List<int>();

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            ints.Add(i);
            ints.RemoveAll((int n) => n % 2 == 0);
        }
    }
}