using System.Collections;
using UnityEngine;

public class PoolItem : MonoBehaviour
{
    PoolManager pool_manager;

    private bool is_init;
    void Awake()
    {
        pool_manager = GameObject.FindFirstObjectByType<PoolManager>();
    }

    void OnEnable()
    {
        if (!is_init)
        {
            this.is_init = true;
        }
    }
    void Start()
    {
        StartCoroutine(ReturnRoutine());
    }

    IEnumerator ReturnRoutine()
    {
        yield return new WaitForSeconds(5f);

        pool_manager.pool.Release(this.gameObject);
        this.gameObject.SetActive(false);
    }
}
