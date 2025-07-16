using UnityEngine;

public class EnemyGenarator : MonoBehaviour
{
    private float cur_time;
    private float crate_time;

    private float min_time = 1f;
    private float max_time = 5f;

    public GameObject enemy_factory;

    void Start()
    {
        InitCreatetime();
    }

    void Update()
    {
        cur_time += Time.deltaTime;

        if (cur_time >= crate_time)
        {
            InitCreatetime();
            GameObject enemy = Instantiate(enemy_factory, this.transform.position, Quaternion.identity);
        }
    }

    private void InitCreatetime()
    {
        this.crate_time = Random.Range(min_time, max_time);
        this.cur_time = 0f;
    }

}
