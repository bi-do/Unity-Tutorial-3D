
using UnityEngine;
using UnityEngine.InputSystem;

namespace NewInput
{
    public class PlayerController : MonoBehaviour
    {
        private CharacterController cc;

        private Vector2 move_input;
        public float move_spd = 5f;

        public InputActionAsset input_act_Asset;

        private InputAction move_action;
        private InputAction jump_action;
        private InputAction interaction_action;
        private InputAction attack_action;


        void Start()
        {
            this.move_action = InputSystem.actions.FindAction("Move");
            this.jump_action = InputSystem.actions.FindAction("Jump");
            this.interaction_action = InputSystem.actions.FindAction("Interaction");
            this.attack_action = InputSystem.actions.FindAction("Attack");

            this.cc = this.GetComponent<CharacterController>();

        }

        // Update is called once per frame
        void Update()
        {
            this.move_input = this.move_action.ReadValue<Vector2>();

            if (move_input != Vector2.zero)
            {
                Debug.Log($"Move : {this.move_input}");
                Vector3 dir = new Vector3(this.move_input.x, 0, this.move_input.y).normalized;
            }


            if (this.jump_action.WasPressedThisFrame())
            {
                Debug.Log("Jump");
            }
            if (this.interaction_action.IsPressed())
            {
                Debug.Log("Interaction");
            }
            if (this.attack_action.WasPressedThisFrame())
            {
                Debug.Log("Attack");
            }
        }
    }

}
