using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public void AddItem(string param_name)
    {
        Debug.Log($"{param_name} 획득");
    }

    public void RemoveItem(string param_name)
    {
        Debug.Log($"{param_name} 버림");
    }

    public void InstallItem(string param_name)
    {
        Debug.Log($"{param_name} 장착");
    }


  
    
}
