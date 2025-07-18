using System.Collections;
using UnityEngine;

public class CrossBow : MonoBehaviour
{
    public GameObject arrow_prefab;
    public Transform shoot_tf;

    private Ray ray;
    private RaycastHit ray_hit;

    private bool is_targeting;
    public bool is_shoot;

    void Start()
    {
        ray = new Ray(this.shoot_tf.position, this.shoot_tf.forward);
        ray_hit = new RaycastHit();
    }

    void Update()
    {
        this.is_targeting = Physics.Raycast(ray, out ray_hit);
        Debug.DrawRay(this.shoot_tf.position, this.shoot_tf.forward, Color.red);

        if (is_targeting && !is_shoot && ray_hit.distance < 10)
        {
            StartCoroutine(ShootRoutine());
        }
    }

    IEnumerator ShootRoutine()
    {
        this.is_shoot = true;
        GameObject arrow_temp =
           Instantiate(
           this.arrow_prefab,
           this.shoot_tf.position,
           Quaternion.identity,
           this.transform);

        Quaternion rot = Quaternion.Euler(new Vector3(90, 0, 0));
        arrow_temp.transform.rotation = rot;

        yield return new WaitForSeconds(3f);
        this.is_shoot = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(this.shoot_tf.position, this.shoot_tf.forward);
    }

}
