using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // 오브젝트 즉시 파괴

            Destroy(collision.gameObject, 10f); // 오브젝트 지연 파괴
        }
    }

}
