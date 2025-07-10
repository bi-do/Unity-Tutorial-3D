using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolQueue : MonoBehaviour
{
    public Queue<GameObject> obj_queue = new Queue<GameObject>();

    public GameObject obj_prefab;
    public Transform parent;

    private int obj_cnt = 100;

    void Start()
    {
        CreateObject();
    }

    /// <summary> 오브젝트 풀 채우기 </summary>
    private void CreateObject()
    {
        for (int i = 0; i < this.obj_cnt; i++)
        {
            GameObject temp_obj = Instantiate(this.obj_prefab, parent);
            EnqueueObject(temp_obj);
        }

    }

    public void EnqueueObject(GameObject param_obj)
    {
        this.obj_queue.Enqueue(param_obj);
        param_obj.SetActive(false);
    }

    public GameObject DequeueObject()
    {
        if (this.obj_queue.Count < 10)
        {
            CreateObject();
        }
        GameObject obj = this.obj_queue.Dequeue();
        obj.SetActive(true);
        return obj;

    }
}
