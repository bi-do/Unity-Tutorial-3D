using System.Collections;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class HanoiTower : MonoBehaviour
{
    public enum HanoiLv { Lv1 = 3, Lv2, Lv3 };
    public HanoiLv hanoi_lv;
    public GameObject[] donut_prefab;
    public BarStack[] bars;

    public static GameObject cur_donut = null;
    public static bool isSelected;

    void Start()
    {
        StartCoroutine(InitRoutine());
    }

    IEnumerator InitRoutine()
    {

        for (int i = (int)this.hanoi_lv - 1; i >= 0; i--)
        {
            GameObject donut = Instantiate(this.donut_prefab[i]);
            bars[0].PushDonut(donut);

            donut.transform.position = new Vector3(-5f, 5f, 0);

            yield return new WaitForSeconds(1f);
        }
    }

}
