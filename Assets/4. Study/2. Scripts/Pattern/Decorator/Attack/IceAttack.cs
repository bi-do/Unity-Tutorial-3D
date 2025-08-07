using Pattern.Decorator;
using UnityEngine;

public class IceAttack : AttackDecorator
{
    public IceAttack(IAttack attack) : base(attack)
    {
    }

    public override void Excute()
    {
        base.Excute();
        Debug.Log("얼음 속성 추가 피해");
    }
}