using UnityEngine;

public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee)
    {

    }

    public override string Description()
    {
        return base.Description() + "Mocha";
    }

    public override int Cost()
    {
        return base.Cost() + 1000;
    }
}