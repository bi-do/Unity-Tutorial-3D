using UnityEngine;
using UnityEngine.InputSystem;

public class CamRotate : MonoBehaviour
{
    float x, y;
    public float mx, my;
    private float rot_speed = 200;

    // Update is called once per frame
    void Update()
    {

        this.x = Input.GetAxis("Mouse X");
        this.y = Input.GetAxis("Mouse Y");

        mx += x * rot_speed * Time.deltaTime;
        my += y * rot_speed * Time.deltaTime;

        my = Mathf.Clamp(my, -90f, 90f);

        this.transform.eulerAngles = new Vector3(-my, mx, 0);
    }
}
