using UnityEngine;

public abstract class PizzaStore : MonoBehaviour
{
    public Pizza OrderPizza(string param_type)
    {
        Pizza pizza = CreatePizza(param_type);
        return pizza;
    }

    protected abstract Pizza CreatePizza(string param_type);
}