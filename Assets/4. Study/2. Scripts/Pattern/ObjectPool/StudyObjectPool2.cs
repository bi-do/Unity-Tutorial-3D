using UnityEngine;
using UnityEngine.Pool;

public class StudyObjectPool2 : StudyGenericSingleton<StudyObjectPool2>
{
    public ObjectPool<GameObject> obj_pool;
    public GameObject obj_prefab;

    void Awake()
    {
        obj_pool = new ObjectPool<GameObject>(CrateObject);
    }


    private GameObject CrateObject()
    {
        GameObject obj = Instantiate(this.obj_prefab, this.transform);
        obj.SetActive(false);

        return obj;
    }

    private void GetObject(GameObject obj)
    {
        Debug.Log("Dequeue 호출");
        obj.SetActive(false);
    }

    private void ReleaseObject(GameObject obj)
    {
        Debug.Log("Dequeue 호출");
        obj.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = this.obj_pool.Get();
        }


    }
}