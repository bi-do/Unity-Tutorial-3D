using UnityEngine;

public class Movement : MonoBehaviour
{
    private float h, v;
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        this.h = Input.GetAxisRaw("Horizontal");
        this.v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(this.h, 0, this.v);
        this.transform.position += dir * Time.deltaTime * this.speed;
    }
}
