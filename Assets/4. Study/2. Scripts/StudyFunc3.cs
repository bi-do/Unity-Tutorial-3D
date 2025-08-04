using System;
using UnityEngine;

public class StudyFunc3 : MonoBehaviour
{
    public int hp = 100;

    public Func<int> GetHp;

    public Func<float, float> GetRemainHp;

    public Func<string> GetAction;

    void Start()
    {
        this.GetHp = () => this.hp;

        this.GetRemainHp = (float dmg) => this.hp - dmg;

        this.GetAction = () =>
        {
            int temp = GetHp();
            if (temp > 50)
            {
                return " 공격";
            }
            else if (temp > 20)
            {
                return "도망";
            }
            else if (temp <= 0)
                return "죽음";

            return "";
        };
    }
}