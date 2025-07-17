using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        Vector3 dir = Vector3.up;

        this.transform.Translate(dir * speed * Time.deltaTime);
    }

    void OnDisable()
    {
        PlayerFire.Instance.bullets.Enqueue(this.gameObject);
    }
}
