using UnityEngine;
using Pattern.Decorator;

public class BasicAttack : IAttack
{
    public void Excute()
    {
        Debug.Log("기본 공격 피해");
    }
}