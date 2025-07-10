using System.Collections;
using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class HanoiTower : MonoBehaviour
{
    public enum HanoiLv { Lv1 = 3, Lv2, Lv3 };
    public HanoiLv hanoi_lv;
    public GameObject[] donut_prefab;
    public BarStack[] bars;

    public TextMeshProUGUI cnt_text;

    public static GameObject cur_donut = null;
    public static BarStack cur_bar = null;
    public static bool isSelected;
    public static int move_cnt;

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
        move_cnt = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && cur_donut != null)
        {
            cur_bar.bar_stack.Push(cur_donut);

            isSelected = false;
            cur_donut = null;
        }
        this.cnt_text.text = move_cnt.ToString();
    }


}
