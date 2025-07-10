using System.Collections;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    private ObjectPoolQueue pool;
    private Rigidbody bullet_rb;
    private int destroy_time = 3;
    private int bullet_force = 20;

    void Awake()
    {
        this.pool = FindFirstObjectByType<ObjectPoolQueue>();
        this.bullet_rb = this.GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        this.bullet_rb.linearVelocity = Vector3.zero;
        this.bullet_rb.angularVelocity = Vector3.zero;
        this.bullet_rb.AddForce(Vector3.forward * this.bullet_force , ForceMode.Impulse);
        StartCoroutine(ReturnPoolRoutine());
    }

    IEnumerator ReturnPoolRoutine()
    {
        yield return new WaitForSeconds(this.destroy_time);
        this.pool.EnqueueObject(this.gameObject);
    }
}
