#define DEBUG_TEST

using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class PlayerFire : Singleton<PlayerFire>
{
    public GameObject bullet_factory;
    public Transform fire_pos;

    public int pool_size = 20;

    // public GameObject[] bullets;
    public Queue<GameObject> bullets;

    void Start()
    {
        // bullets = new GameObject[pool_size];
        bullets = new Queue<GameObject>();

        for (int i = 0; i < pool_size; i++)
        {
            GameObject bullet = Instantiate(bullet_factory, fire_pos.position, Quaternion.identity);
            bullet.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_STANDALONE || UNITY_EDITOR || DEBUG_TEST
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("마우스 클릭");
            if (bullets.Count > 0)
            {
                GameObject bullet = this.bullets.Dequeue();
                bullet.transform.position = fire_pos.position;
                bullet.SetActive(true);
            }
            else
            {
                Debug.Log("총알없어 이놈아");
            }
#elif UNITY_ANDROID
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("손가락 터치");
            if (bullets.Count > 0)
            {
                GameObject bullet = this.bullets.Dequeue();
                bullet.transform.position = fire_pos.position;
                bullet.SetActive(true);
            }
            else
            {
                Debug.Log("총알없어 이놈아");
            }
#else
            Debug.Log("그 외 나머지 플랫폼");
#endif
            // foreach (GameObject element in bullets)
            // {
            //     if (!element.activeSelf)
            //     {
            //         element.transform.position = fire_pos.position;
            //         element.SetActive(true);
            //         break;
            //     }
            // }
        }

    }
}
