using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float move_speed = 10f;
    private float h, v;

    // Update is called once per frame
    void Update()
    {
        this.h = Input.GetAxisRaw("Horizontal");
        this.v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, v ,0);

        this.transform.position += dir * move_speed * Time.deltaTime;
    }
}
