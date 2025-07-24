using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    private Transform target_tf;
    private NavMeshAgent agent;

    void Start()
    {
        this.target_tf = GameObject.FindWithTag("Player").transform;
        this.agent = this.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        this.agent.SetDestination(this.target_tf.position);
    }
}
