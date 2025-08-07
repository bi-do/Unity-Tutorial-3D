using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    public void StartSound(string param_name)
    {
        Debug.Log($"{param_name} 시작");
    }

    public void PasueSound(string param_name)
    {
        Debug.Log($"{param_name} 일시 정지");
    }

    public void StopSound(string param_name)
    {
        Debug.Log($"{param_name} 종료");
    }
}