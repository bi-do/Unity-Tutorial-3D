using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform target_tf;

    void Start()
    {
        this.agent = this.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(target_tf.position);
    }
}
