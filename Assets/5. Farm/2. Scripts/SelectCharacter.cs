using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    [SerializeField] private Transform center_pivot;
    [SerializeField] private Button[] turn_btns;
    [SerializeField] private Button select_btn_UI;

    [SerializeField] private Animator[] anims;



    private int cur_index = 0;

    private bool isTurn;
    private float turn_spd = 7f;

    void Start()
    {
        turn_btns[0].onClick.AddListener(() => Turn(true));
        turn_btns[1].onClick.AddListener(() => Turn(false));

        this.select_btn_UI.onClick.AddListener(Select);
    }



    private void Turn(bool isLeft)
    {
        int value = isLeft ? -1 : 1;

        float angle = value * 90f;
        Quaternion end_rot = this.center_pivot.rotation * Quaternion.Euler(0, angle, 0);
        if (!isTurn)
        {
            this.cur_index += value;
            if (cur_index < 0)
            {
                cur_index = 3;
            }
            else if (cur_index > 3)
            {
                cur_index = 0;
            }
            isTurn = true;
            StartCoroutine(TrunRoutine(end_rot));
        }
    }

    IEnumerator TrunRoutine(Quaternion angle)
    {
        while (true)
        {
            yield return null;

            this.center_pivot.rotation = Quaternion.Slerp(center_pivot.rotation, angle, turn_spd * Time.deltaTime);

            float temp_angle = Quaternion.Angle(this.center_pivot.rotation, angle);

            if (temp_angle <= 0.01f)
            {
                this.center_pivot.rotation = angle;
                isTurn = false;
                break;
            }
        }
    }

    private void Select()
    {
        Debug.Log($"현재 캐릭터는 {cur_index + 1}번째 캐릭터 입니다.");
        StartCoroutine(SelectRoutine());

    }

    IEnumerator SelectRoutine()
    {
        this.anims[cur_index].SetTrigger("Select");

        yield return new WaitForSeconds(3f);

        Fade.on_fade_act?.Invoke(3f, Color.black, true, null);

        yield return new WaitForSeconds(3.5f);

        // Load Scene
    }


}
