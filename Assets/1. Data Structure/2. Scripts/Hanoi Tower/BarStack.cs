using System.Collections.Generic;
using UnityEngine;

public class BarStack : MonoBehaviour
{
    public enum BarType { LEFT, CENTER, RIGHT }
    public BarType bar_type;

    public Stack<GameObject> bar_stack = new Stack<GameObject>();

    void Start()
    {

    }

    public bool CheckDonut(GameObject param_donut)
    {
        if (bar_stack.Count > 0)
        {
            int push_num = param_donut.GetComponent<Donut>().donut_num;
            int peek_num = this.bar_stack.Peek().GetComponent<Donut>().donut_num;

            if (push_num < peek_num)
                return true;
            else
            {
                Debug.LogError("현재 넣으려는 도넛의 크기가 선택한 기둥의 맨 위의 도넛의 크기보다 큽니다.");
                return false;
            }
        }
        return true;

    }

    public void PushDonut(GameObject param_donut)
    {
        if (!CheckDonut(param_donut))
        {
            return;
        }

        HanoiTower.isSelected = false;
        HanoiTower.cur_donut = null;

        HanoiTower.move_cnt++;

        param_donut.transform.position = this.transform.position + Vector3.up * 5f;
        Rigidbody param_donut_rb = param_donut.GetComponent<Rigidbody>();

        param_donut_rb.linearVelocity = Vector3.zero;
        param_donut_rb.angularVelocity = Vector3.zero;

        this.bar_stack.Push(param_donut);
    }

    public GameObject PopDonut()
    {
        if (this.bar_stack.Count == 0)
        {
            Debug.LogError("현재 택한 기둥에 꺼낼 도넛이 없습니다.");
            return null;
        }
        HanoiTower.isSelected = true;
        return this.bar_stack.Pop();
    }

    void OnMouseDown()
    {
        if (!HanoiTower.isSelected)
        {
            HanoiTower.cur_donut = PopDonut();
        }
        else
        {
            PushDonut(HanoiTower.cur_donut);
        }
    }

}
