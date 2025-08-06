using UnityEngine;

public class StudyGenericSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<T>();
                if (instance == null)
                {
                    GameObject temp = new GameObject(typeof(T).ToString());
                    instance = temp.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
        }
        else
            Destroy(this.gameObject);
    }
}
