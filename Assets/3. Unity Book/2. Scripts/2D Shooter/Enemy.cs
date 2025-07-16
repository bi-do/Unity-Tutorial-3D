using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 dir;
    public float speed = 5f;

    GameObject player;
    public GameObject explosion_effect;

    void Start()
    {


        int ran_value = Random.Range(0, 10);

        if (ran_value < 3)
        {
            player = GameObject.FindWithTag("Player");
            this.dir = player.transform.position - this.transform.position;
            dir = dir.normalized;
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
        if (collision.gameObject.CompareTag("Bullet"))
        {
            GameObject sm_obj = GameObject.FindWithTag("ScoreManager");
            ScoreManager sm = sm_obj.GetComponent<ScoreManager>();

            sm.AddScore(1);

            GameObject explosion = Instantiate(this.explosion_effect, this.transform.position, Quaternion.identity);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
