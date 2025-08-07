using UnityEngine;

public class LegacyPizzaStore : PizzaStore
{
    protected override Pizza CreatePizza(string param_type)
    {
        if (param_type.Equals("Normal"))
        {
            return new CheesePizza();
        }
        else if (param_type.Equals("Special"))
        {
            return new PotatoPizza();
        }

        return null;
    }
}