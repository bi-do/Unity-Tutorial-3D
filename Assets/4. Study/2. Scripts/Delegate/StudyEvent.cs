using UnityEngine;

public class StudyEvent : MonoBehaviour
{
    public delegate void InputKeyHandler(string msg);
    public event InputKeyHandler on_input_key;

    void Start()
    {
        this.on_input_key += InputKeyEvent;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.on_input_key?.Invoke("Hello");
        }
    }

    private void InputKeyEvent(string msg)
    {
        Debug.Log(msg);
    }
}
