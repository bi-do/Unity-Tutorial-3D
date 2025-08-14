using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AnimalController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;

    private string anim_bool_walk = "isWalk";

    [SerializeField] private float wander_radius = 15f;

    private float min_wait_time = 1f;
    private float max_wait_time = 5f;

    void Awake()
    {
        this.agent = this.GetComponent<NavMeshAgent>();
        this.anim = this.GetComponent<Animator>();
    }

    void Start()
    {
        StartCoroutine(PatrolRoutine());
    }

    IEnumerator PatrolRoutine()
    {
        while (true)
        {
            SetRandomDst();
            anim.SetBool(anim_bool_walk, true);

            yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance);

            anim.SetBool(anim_bool_walk, false);
            float idle_time = Random.Range(min_wait_time, max_wait_time);
            yield return new WaitForSeconds(idle_time);
        }
    }

    private void SetRandomDst()
    {
        Vector3 random_dir = Random.insideUnitSphere * wander_radius;
        random_dir += this.transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(random_dir, out hit, wander_radius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AnimalEvent.fail_act?.Invoke();
            Debug.Log("동물 피하기 실패");
        }
    }
}
