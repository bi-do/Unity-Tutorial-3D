using UnityEngine;

public class StudySingleton : MonoBehaviour
{
    public static StudySingleton Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(this.gameObject);
    }

    public int number;
}