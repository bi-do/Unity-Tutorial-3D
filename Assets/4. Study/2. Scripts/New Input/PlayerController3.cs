using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

namespace NewInput
{
    public class PlayerController3 : MonoBehaviour
    {
        private CharacterController cc;

        public float move_spd = 5f;

        private Vector2 move_input;

        void Start()
        {
            this.cc = this.GetComponent<CharacterController>();
        }
        void Update()
        {
            Vector3 dir = new Vector3(move_input.x, 0, move_input.y);

            this.cc.Move(dir * move_spd * Time.deltaTime);
        }

        private void OnMove(InputValue param_value)
        {
            this.move_input = param_value.Get<Vector2>();
        }

        private void OnJump(InputValue param_value)
        {
            Debug.Log("OnJump");
        }

        private void OnInteraction(InputValue param_value)
        {
            Debug.Log(param_value.isPressed);
        }

        private void OnAttack(InputValue param_value)
        {
            Debug.Log("OnAttack");
        }




    }

}
