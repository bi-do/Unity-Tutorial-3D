using UnityEngine;

public class MochaDecorator : CoffeeDecorator
{
    public MochaDecorator(ICoffee coffee) : base(coffee)
    {

    }

    public override string Description()
    {
        return base.Description() + "Milk";
    }

    public override int Cost()
    {
        return base.Cost() + 500;
    }
}