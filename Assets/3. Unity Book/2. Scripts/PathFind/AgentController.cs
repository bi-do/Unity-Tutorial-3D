using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    private Transform player_tf;
    private NavMeshAgent agent;
    public Transform[] points;
    public int point_index;
    Vector3 temp;

    void Start()
    {
        this.agent = this.GetComponent<NavMeshAgent>();
        // this.player_tf = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        // this.agent.SetDestination(player_tf.transform.position);
        this.agent.SetDestination(points[this.point_index].position);

        if (this.agent.remainingDistance <= 1f && this.agent.destination == this.temp)
        {
            this.temp = this.agent.destination;
            ++this.point_index;
            Debug.Log($"목적지 변경 : {this.point_index}");
            Debug.Log($"현재 목적지 : {this.agent.destination} , temp : {this.temp}");

            // int temp = this.point_index;
            // do
            // {
            //     this.point_index = Random.Range(0, points.Length);
            // } while (temp == this.point_index);
        }
    }
}
