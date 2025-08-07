using UnityEngine;

public class SoundSystem : MonoBehaviour
{

    public void StartQuest(string param_name)
    {
        Debug.Log($"{param_name} 획득");
    }

    public void HasQuest(string param_name)
    {
        Debug.Log($"{param_name} 유무");
    }

    public void CompleteQuest(string param_name)
    {
        Debug.Log($"{param_name} 포기");
    }
}