using System.Collections;
using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.UI;

public class HanoiTower : MonoBehaviour
{
    public enum HanoiLv { Lv1 = 3, Lv2, Lv3 };
    public HanoiLv hanoi_lv = HanoiLv.Lv1;
    public GameObject[] donut_prefab;
    public BarStack[] bars;

    public TextMeshProUGUI cnt_text;
    public Button answer_btn;

    public static GameObject cur_donut = null;
    public static BarStack cur_bar = null;
    public static bool isSelected;
    public static int move_cnt;

    void Awake()
    {
        this.answer_btn.onClick.AddListener(HanoiAnswer);
    }

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

    public void HanoiAnswer()
    {
        HanoidRoutine((int)this.hanoi_lv, 0, 1, 2);
    }

    private void HanoidRoutine(int param_cnt, int param_from, int param_temp, int param_to)
    {
        if (param_cnt == 0)
            return;

        if (param_cnt == 1)
        {
            Debug.Log($"{param_cnt}번 도넛을 {param_from}에서 {param_to}로 이동");
        }
        else
        {
            HanoidRoutine(param_cnt - 1, param_from, param_to, param_temp);
            Debug.Log($"{param_cnt}번 도넛을 {param_from}에서 {param_to}로 이동");
            HanoidRoutine(param_cnt - 1, param_temp, param_from, param_to);
        }

    }

}
