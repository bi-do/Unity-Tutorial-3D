using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class EnemyGenarator : Singleton<EnemyGenarator>
{
    private int pool_size = 20;

    public GameObject enemy_factory;

    // public GameObject[] enemy_pool;
    public Queue<GameObject> enemy_pool;

    public Transform[] spawn_point_arr;

    private float cur_time;
    private float crate_time;

    private float min_time = 1f;
    private float max_time = 5f;

    void Start()
    {
        enemy_pool = new Queue<GameObject>();

        for (int i = 0; i < pool_size; i++)
        {
            GameObject temp = Instantiate(enemy_factory);
            enemy_pool.Enqueue(temp);
            temp.SetActive(false);
        }

        InitCreatetime();
    }

    void Update()
    {
        cur_time += Time.deltaTime;

        if (cur_time >= crate_time)
        {
            InitCreatetime();
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        if (enemy_pool.Count > 0)
        {
            int ran_value = Random.Range(0, spawn_point_arr.Length);

            GameObject temp = enemy_pool.Dequeue();

            temp.transform.position = spawn_point_arr[ran_value].position;
            temp.SetActive(true);
        }
    }

    private void InitCreatetime()
    {
        this.crate_time = Random.Range(min_time, max_time);
        this.cur_time = 0f;
    }

}
