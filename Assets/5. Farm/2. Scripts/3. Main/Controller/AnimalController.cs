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

            // Agent가 길을 찾지 못하고 , agent의 목적지 남은 거리가 stop 거리보다 작을ㄸ
            yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance);

            anim.SetBool(anim_bool_walk, false);
            float idle_time = Random.Range(min_wait_time, max_wait_time);
            yield return new WaitForSeconds(idle_time);
        }
    }

    private void SetRandomDst()
    {
        // Random.Random.insideUnitSphere 은 Vector3.zero (원점) 기준 반지름이 1인 구 안에서의 무작위 벡터값을 뱉음
        // 반지름을 곱해주면 ( wander_radius ) 랜덤한 벡터값의 범위 증가
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
