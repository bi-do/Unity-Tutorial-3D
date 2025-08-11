using UnityEngine;
using UnityEngine.InputSystem;

namespace Farm
{
    public class PlayerController : MonoBehaviour
    {
        private Animator anim;

        private PlayerInput player_input;

        private CharacterController cc;
        private Vector3 move_input;

        private float move_spd = 2f;
        private float turn_spd = 10f;

        void Awake()
        {
            cc = GetComponent<CharacterController>();
            anim = GetComponent<Animator>();
        }

        void Update()
        {
            this.cc.Move(move_input * this.move_spd * Time.deltaTime);
            Turn();
        }

        void OnMove(InputValue value)
        {
            Vector2 temp = value.Get<Vector2>();
            this.move_input = new Vector3(temp.x, 0, temp.y);
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

    }
}
