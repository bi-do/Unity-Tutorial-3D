using UnityEngine;

public class SingletonEx2 : MonoBehaviour
{
    public static SingletonEx2 Instance
    {
        get;
        private set;
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
