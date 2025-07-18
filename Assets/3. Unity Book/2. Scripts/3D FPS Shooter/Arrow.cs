using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float move_speed = 100f;
    public bool is_move = true;

    void Update()
    {
        if (!is_move)
            return;

        this.transform.position += this.transform.up * move_speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.is_move = false;

            this.transform.SetParent(other.transform);
            Vector3 close_pos = other.ClosestPoint(this.transform.position);
            this.transform.position = close_pos;

        }
    }
}
