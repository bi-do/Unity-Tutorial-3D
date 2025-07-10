using System.ComponentModel;
using UnityEngine;

public class Fibonacci : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log(FibonacciFunc(i));
        }
    }



    private int FibonacciFunc(int param_n)
    {
        if (param_n < 2)
        {
            return param_n;
        }
        else
        {
            return FibonacciFunc(param_n - 1) + FibonacciFunc(param_n - 2);
        }
    }
}
