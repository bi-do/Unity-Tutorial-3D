using System.Collections;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bomb_prefab;

    public int range_x = 5;
    public int range_y = 5;


    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            RespawnBomb();
        }
    }

    private void RespawnBomb()
    {
        float ran_x = Random.Range(-range_x, range_x + 1);
        float ran_y = Random.Range(-range_y, range_y + 1);

        Vector3 ran_pos = new Vector3(ran_x, 10f, ran_y);

        Instantiate(this.bomb_prefab, ran_pos, Quaternion.identity);
    }
}
