using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    public ObjectPool<GameObject> pool;
    public GameObject pool_prefab;

    void Awake()
    {
        pool = new ObjectPool<GameObject>(CreateObject);
    }

    private GameObject CreateObject()
    {
        GameObject obj = Instantiate(pool_prefab);
        obj.SetActive(false);

        return obj;
    }

    private void OnGetObject(GameObject obj)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;


        obj.transform.position = Vector3.zero;
        obj.SetActive(true);
    }

    private void OnReleaseObject(GameObject obj)
    {
        obj.SetActive(false);
    }

    private void OnDestroyObject(GameObject obj)
    {
        Destroy(obj);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
             pool.Get().SetActive(true);
        }
    }
}
