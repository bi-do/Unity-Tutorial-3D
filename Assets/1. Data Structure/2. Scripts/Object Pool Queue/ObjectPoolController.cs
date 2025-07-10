using UnityEngine;

public class ObjectPoolController : MonoBehaviour
{
    ObjectPoolQueue pool;

    void Awake()
    {
        this.pool = FindFirstObjectByType<ObjectPoolQueue>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject obj = this.pool.DequeueObject();
            obj.transform.localPosition = Vector3.zero;
        }
    }
}
