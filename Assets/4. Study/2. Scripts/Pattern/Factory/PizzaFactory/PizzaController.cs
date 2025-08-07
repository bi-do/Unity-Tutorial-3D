using System.Collections;
using UnityEngine;

public class PizzaController : MonoBehaviour
{
    PizzaStore pizza_store = null;
    Pizza pizza = null;

    void Start()
    {
        StartCoroutine(PizzaRoutine());
    }

    IEnumerator PizzaRoutine()
    {
        this.pizza_store = new LegacyPizzaStore();
        this.pizza = this.pizza_store.OrderPizza("Normal");
        Debug.Log($"주문하신 {this.pizza} 나왔습니다.");


        yield return new WaitForSeconds(1f);
        this.pizza = this.pizza_store.OrderPizza("Special");
        Debug.Log($"주문하신 {this.pizza} 나왔습니다.");

        this.pizza_store = new NewPizzaStore();
        this.pizza = this.pizza_store.OrderPizza("Normal");
        Debug.Log($"주문하신 {this.pizza} 나왔습니다.");

        yield return new WaitForSeconds(1f);
        this.pizza = this.pizza_store.OrderPizza("Special");
        Debug.Log($"주문하신 {this.pizza} 나왔습니다.");
    }
}