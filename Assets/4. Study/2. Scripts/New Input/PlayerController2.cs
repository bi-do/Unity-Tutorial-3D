using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2 : MonoBehaviour
{
    private CharacterController cc;

    private Vector2 move_input;
    public float move_spd = 5f;

    private PlayerInput player_input;

    private InputAction jump_action;
    private InputAction move_action;


    void Awake()
    {
        this.cc = GetComponent<CharacterController>();

        this.player_input = this.GetComponent<PlayerInput>();
        this.move_action = player_input.actions.FindAction("Move");
        this.jump_action = player_input.actions.FindAction("Jump");
    }

    void OnEnable()
    {
        this.move_action.Enable();
        this.move_action.performed += Move;
        this.move_action.canceled += MoveCancel;

        this.move_action.Enable();
        this.jump_action.performed += Jump;
    }

    void OnDisable()
    {
        this.move_action.Disable();
        this.move_action.performed -= Move;
        this.move_action.canceled -= MoveCancel;

        this.jump_action.Disable();
        this.jump_action.performed -= Jump;
    }

    void Update()
    {
        Vector3 dir = new Vector3(move_input.x, 0, move_input.y);


        this.cc.Move(dir * this.move_spd * Time.deltaTime);
    }

    public void Move(InputAction.CallbackContext context)
    {
        this.move_input = context.ReadValue<Vector2>();
    }

    public void MoveCancel(InputAction.CallbackContext context)
    {
        this.move_input = Vector2.zero;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump");
    }
}
