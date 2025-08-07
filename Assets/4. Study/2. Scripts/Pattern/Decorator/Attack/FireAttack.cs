using Pattern.Decorator;
using UnityEngine;

public class FireAttack : AttackDecorator
{
    public FireAttack(IAttack attack) : base(attack)
    {
    }

    public override void Excute()
    {
        base.Excute();
        Debug.Log("불 속성 추가 피해");
    }
}