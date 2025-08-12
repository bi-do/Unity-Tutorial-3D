using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Farm
{
    public class PlayerController : MonoBehaviour
    {
        private Animator anim;
        private string anim_move_float = "Move";

        // private PlayerInput player_input;

        private CharacterController cc;
        private Vector3 move_input;
        private bool isRun;

        private float cur_spd;
        private float walk_spd = 2f;
        private float run_spd = 5f;
        private float turn_spd = 10f;

        void Awake()
        {
            cc = GetComponent<CharacterController>();
            anim = GetComponent<Animator>();
        }

        void Update()
        {
            this.cc.Move(move_input * this.cur_spd * Time.deltaTime);
            Turn();
            SetMoveState();
        }

        private void OnMove(InputValue value)
        {
            Vector2 temp = value.Get<Vector2>();
            this.move_input = new Vector3(temp.x, 0, temp.y);
        }

        private void OnRun(InputValue value)
        {
            this.isRun = value.isPressed;
        }

        private void Turn()
        {
            if (this.move_input != Vector3.zero)
            {
                // 목표 회전 값
                Quaternion target_rot = Quaternion.LookRotation(move_input);

                // 부드러운 회전 ( 현재 회전각 , 목표 회전각 , 목표 값까지 가는 비율 == 백분율 . 1 = 100% )
                transform.rotation = Quaternion.Slerp(this.transform.rotation, target_rot, turn_spd * Time.deltaTime);

            }
        }

   

        /// <summary> 움직이는 상태에 따라 각 수치 상태 변환 </summary>
        private void SetMoveState()
        {
            // Lerp한 움직임을 위한 목표 값. ( 목표값을 향해 anim_value가 계속 증감 )
            float target_value = 0f;

            if (this.move_input != Vector3.zero)
            {
                target_value = this.isRun ? 1 : 0.5f;
                cur_spd = this.isRun ? run_spd : walk_spd;
            }
            // 실제 적용 값
            float anim_value = anim.GetFloat(this.anim_move_float);

            anim_value = Mathf.Lerp(anim_value, target_value, 10f * Time.deltaTime);

            anim.SetFloat(this.anim_move_float, anim_value);
        }

    }
}
