using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                T temp = FindFirstObjectByType<T>();
                if (temp == null)
                {
                    GameObject obj_temp = new GameObject(typeof(T).ToString());
                    obj_temp.AddComponent<T>();

                    instance = obj_temp.GetComponent<T>();
                }
                else
                {
                    instance = temp;
                }
            }
            return instance;
        }
    }
    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
