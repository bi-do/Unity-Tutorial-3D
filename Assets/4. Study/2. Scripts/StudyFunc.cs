using System;
using UnityEngine;

public class StudyFunc : MonoBehaviour
{
    public enum Buff { A, B, C };
    public Buff buff;
    public float dmg;

    public Func<Buff, float, float> my_func;

    void Start()
    {
        
        my_func?.Invoke(this.buff, this.dmg);
    }

    private float AddMethod(Buff param_buff, float param_dmg)
    {
        int result = 0;
        switch (param_buff)
        {
            case Buff.A:

                result = 10;
                break;
            case Buff.B:
                result = 20;
                break;
            case Buff.C:
                result = 100;
                break;
        }

        return param_dmg * result;
    }


    private int MinusMethod(int num1, int num2)
    {
        return num1 - num2;
    }
}