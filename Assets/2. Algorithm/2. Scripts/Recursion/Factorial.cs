using UnityEngine;

public class Factorial : MonoBehaviour
{

    public int factorial_input_max = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < this.factorial_input_max; i++)
        {
            Debug.Log(FactorialFunc(this.factorial_input_max));
        }
    }

    private int FactorialFunc(int param)
    {
        if (param <= 1)
        {
            return 1;
        }
        else
            return param * FactorialFunc(param - 1);
    }
}
