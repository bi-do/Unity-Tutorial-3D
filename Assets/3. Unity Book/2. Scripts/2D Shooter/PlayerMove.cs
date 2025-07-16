using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5;

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, v, 0);

        transform.Translate(dir * 5*Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("마우스 왼쪽 클릭");
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("마우스 왼쪽 클릭 ( GetMousebtnDown )");
        }
    }


}
