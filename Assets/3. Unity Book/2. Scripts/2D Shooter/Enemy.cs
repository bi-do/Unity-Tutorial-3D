using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector3 dir;
    public float speed = 5f;

    GameObject player = null;
    public GameObject explosion_effect;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    void OnEnable()
    {
        this.transform.rotation = Quaternion.identity;
        int ran_value = Random.Range(0, 10);

        if (ran_value < 3)
        {
            this.dir = this.player.transform.position - this.transform.position;
            dir = dir.normalized;
            if (dir.y > 0)
            {
                Debug.LogError(
                    $"현재 플레이어의 위치 : {this.player.transform.position}, 적의 현재 벡터 : {this.transform.position}, y값 넘은 적 방향 벡터 : {this.dir}");
                Debug.Break();
            }
        }
        else
        {
            dir = Vector3.down;
        }

    }
    void Update()
    {
        this.transform.Translate(dir * speed * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(this.explosion_effect, this.transform.position, Quaternion.identity);
        if (collision.gameObject.CompareTag("Bullet"))
        {
            ScoreManager.Instance.Score++;
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);

        }
        this.gameObject.SetActive(false);
    }

    void OnDisable()
    {
        EnemyGenarator.Instance.enemy_pool.Enqueue(this.gameObject);
    }
}
