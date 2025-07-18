using UnityEngine;

public class FPSPlayerFire : MonoBehaviour
{
    public Transform fire_pos;
    public GameObject bomb_prefab;

    public float throw_power = 15f;

    public GameObject bullet_effect;
    private ParticleSystem ps;

    void Start()
    {
        this.ps = bullet_effect.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo = new RaycastHit();

            if (Physics.Raycast(ray, out hitInfo))
            {
                bullet_effect.transform.position = hitInfo.point;

                bullet_effect.transform.forward = hitInfo.normal;
                Debug.Log("쐇어요");
                print(hitInfo.point + "+" + hitInfo.distance);
                ps.Play();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            GameObject bomb = Instantiate(bomb_prefab, fire_pos.position, Quaternion.identity);

            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward * throw_power, ForceMode.Impulse);

        }
    }
}
