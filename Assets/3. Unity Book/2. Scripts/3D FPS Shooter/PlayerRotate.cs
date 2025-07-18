using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    float x, y;
    public float mx, my;
    private float rot_speed = 200;

    // Update is called once per frame
    void Update()
    {
        this.x = Input.GetAxis("Mouse X");
        mx += x * rot_speed * Time.deltaTime;

        this.transform.eulerAngles = new Vector3(0, mx, 0);
    }
}
