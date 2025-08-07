using UnityEngine;

public class CoffeeDecorator : ICoffee
{
    protected ICoffee coffee;

    public CoffeeDecorator(ICoffee coffee)
    {
        this.coffee = coffee;
    }

    public virtual string Description()
    {
        return this.coffee.Description();
    }

    public virtual int Cost()
    {
        return this.coffee.Cost();
    }

}