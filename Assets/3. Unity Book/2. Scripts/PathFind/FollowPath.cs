using System.IO;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public Pathfind path;
    public float speed = 5f;
    public float mass = 5f;
    public bool is_looping = true;

    private float cur_speed;
    private int cur_path_index;
    private int path_length;
    private Vector3 target_point;

    private Vector3 velocity;

    void Start()
    {
        this.path_length = path.points.Length;
        cur_path_index = 0;

        velocity = transform.forward;
    }

    void Update()
    {
        this.cur_speed = speed * Time.deltaTime;
        target_point = path.GetPoint(cur_path_index);

        if (Vector3.Distance(this.transform.position, target_point) < path.radius)
        {
            if (cur_path_index < path_length - 1)
            {
                cur_path_index++;
            }
            else if (is_looping)
            {
                cur_path_index = 0;
            }
            else
                return;
        }
        if (cur_path_index >= path_length)
            return;

        if (cur_path_index >= path_length - 1 && !is_looping)
        {
            velocity += Steer(target_point, true);
        }
        else
            velocity += Steer(target_point);


        this.transform.position += velocity;
        this.transform.rotation = Quaternion.LookRotation(velocity);
    }

    Vector3 Steer(Vector3 target, bool is_looping = false)
    {
        Vector3 target_dir = target - transform.position;
        float dist = target_dir.magnitude;

        target_dir.Normalize();

        if (is_looping && dist < 10f)
            target_dir *= cur_speed * (dist / 10f);
        else
            target_dir *= cur_speed;

        Vector3 steering_force = target_dir - velocity;
        Vector3 acceleration = steering_force / mass;

        return acceleration;


    }
}
