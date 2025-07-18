using Unity.VisualScripting;
using UnityEngine;

public class SingletonEx5 : MonoBehaviour
{
    private static SingletonEx5 instance;
    private static SingletonEx5 Instance
    {
        get
        {
            if (instance == null)
            {
                SingletonEx5 temp = FindFirstObjectByType<SingletonEx5>();
                if (temp == null)
                {
                    GameObject obj_temp = new GameObject();
                    obj_temp.AddComponent<SingletonEx5>();

                    instance = obj_temp.GetComponent<SingletonEx5>();
                }
                else
                {
                    instance = temp;
                }
            }
            return instance;
        }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}


