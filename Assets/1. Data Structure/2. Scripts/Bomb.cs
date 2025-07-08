using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody bomb_rb;
    public float bomb_time = 4f;
    public float bomb_range = 20f;

    public LayerMask layerMask;

    void Awake()
    {
        this.bomb_rb = this.GetComponent<Rigidbody>();
    }

    void Start()
    {
        Explosion();
    }

    void Explosion()
    {
        StartCoroutine(ExplosionRoutine());
    }

    IEnumerator ExplosionRoutine()
    {
        yield return new WaitForSeconds(this.bomb_time);
        BombForce();
    }

    private void BombForce()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, bomb_range, layerMask);

        foreach (Collider element in colliders)
        {
            Rigidbody temp_rb = element.GetComponent<Rigidbody>();
            temp_rb.AddExplosionForce(500f, transform.position, 10f);
        }
        Destroy(this.gameObject);
    }

}
