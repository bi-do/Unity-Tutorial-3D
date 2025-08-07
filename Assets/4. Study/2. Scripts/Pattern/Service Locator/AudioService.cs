using UnityEngine;

public class AudioService : MonoBehaviour, IAudioService
{
    public void PlaySound()
    {
        Debug.Log("Play Audio");
    }

    public void StopSound()
    {
        Debug.Log("Stop Audio");
    }
}