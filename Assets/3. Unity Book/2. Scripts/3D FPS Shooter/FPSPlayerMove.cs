using Unity.Mathematics;
using UnityEngine;

public class FPSPlayerMove : MonoBehaviour
{
    public float move_speed = 7f;

    public float h, v;

    private CharacterController cc;

    private float gravity = -20f;
    private float y_velocity = 0f;

    public float jump_power = 10f;
    public bool is_jump = false;

    void Start()
    {
        this.cc = this.GetComponent<CharacterController>();
    }
    void Update()
    {
        Move_Legacy();
    }

    private void Move_Legacy()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        dir = Camera.main.transform.TransformDirection(dir);

        if (cc.collisionFlags == CollisionFlags.Below)
        {
            if (this.is_jump)
            {
                is_jump = false;

            }
            this.y_velocity = 0f;
        }
        else
        {
            this.y_velocity += gravity * Time.deltaTime;
            dir.y = this.y_velocity;
        }

        if (Input.GetButtonDown("Jump") && !this.is_jump)
        {
            this.is_jump = true;
            this.y_velocity = this.jump_power;
        }

        cc.Move(dir * move_speed * Time.deltaTime);
    }
}
