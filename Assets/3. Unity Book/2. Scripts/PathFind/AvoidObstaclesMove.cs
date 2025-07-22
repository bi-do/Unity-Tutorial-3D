using System;
using Unity.Mathematics;
using UnityEditor.PackageManager;
using UnityEngine;

public class AvoidObstaclesMove : MonoBehaviour
{
    public float speed = 10f;
    public float mass = 5f;

    public float force = 50f;
    public float min_dist_to_avoid = 5f;

    private float cur_speed;
    private Vector3 target_point;
    public float steering_force = 10f;

    void Start()
    {
        target_point = Vector3.zero;
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                target_point = hit.point;
            }
        }


        Vector3 dir = target_point - transform.position;
        dir.Normalize();

        dir = GetAvoidanceDirection(dir);

        if (Vector3.Distance(target_point, transform.position) < 1f)
        {
            return;
        }

        cur_speed = speed * Time.deltaTime;
        this.transform.position += transform.forward * cur_speed;

        Quaternion rot = Quaternion.LookRotation(dir);
        this.transform.rotation = Quaternion.Slerp(transform.rotation, rot, steering_force * Time.deltaTime); ;
    }

    public Vector3 GetAvoidanceDirection(Vector3 dir)
    {
        RaycastHit hit;
        int layer_mask = 1 << 15;
        if (Physics.Raycast(transform.position, transform.forward, out hit, min_dist_to_avoid, layer_mask))
        {
            Vector3 hit_normal = hit.normal;
            hit_normal.y = 0;
            dir = transform.forward + hit_normal * force;
            dir.Normalize();
        }

        return dir;
    }

}
