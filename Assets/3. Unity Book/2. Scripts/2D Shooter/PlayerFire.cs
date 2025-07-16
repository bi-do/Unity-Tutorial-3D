using Unity.Mathematics;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bullet_factory;
    public Transform fire_pos;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(this.bullet_factory, fire_pos.position, Quaternion.identity);
        }

    }
}
