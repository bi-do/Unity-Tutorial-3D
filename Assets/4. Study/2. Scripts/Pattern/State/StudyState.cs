using System.Collections;
using UnityEngine;

public class StudyState : MonoBehaviour
{
    public IState state;

    private IState idle_state, move_state, attack_state;

    void Start()
    {
        idle_state = this.gameObject.AddComponent<IdleState>();
        move_state = this.gameObject.AddComponent<MoveState>();
        attack_state = this.gameObject.AddComponent<AttackState>();

        this.state = idle_state;
        state.StateEnter();
    }

    void OnDestroy()
    {
        state.StateExit();
    }


    // Update is called once per frame
    void Update()
    {
        state?.StateUpdate();

        #region 상태 변환 기능 테스트
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetState(this.idle_state);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetState(this.move_state);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetState(this.attack_state);
        }
        #endregion
    }

    public void SetState(IState param_state)
    {
        if (this.state != param_state)

        state.StateExit(); // 상태 변경 전 상태 Exit 함수 호출

        this.state = param_state; // 상태 변경

        this.state.StateEnter(); // 상태 변경 후 Enter 함수 호출

    }
}
