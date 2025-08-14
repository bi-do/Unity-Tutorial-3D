using Unity.VisualScripting;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }   

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = new Vector3(target.position.x, this.transform.position.y, this.transform.position.z);
    }
}
