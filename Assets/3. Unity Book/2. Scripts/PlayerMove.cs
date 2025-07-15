using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        transform.Translate(Vector3.right * 5 * Time.deltaTime);

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
