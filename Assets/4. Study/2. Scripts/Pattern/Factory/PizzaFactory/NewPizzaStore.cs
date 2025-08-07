using UnityEngine;

public class NewPizzaStore : PizzaStore
{
   protected override Pizza CreatePizza(string param_type)
    {
        if (param_type.Equals("Normal"))
        {
            return new CheesePizza();
        }
        else if (param_type.Equals("Special"))
        {
            return new BulgogiPizza();
        }

        return null;
    }
}