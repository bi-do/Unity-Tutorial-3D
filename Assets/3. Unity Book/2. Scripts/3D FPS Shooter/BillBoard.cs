using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
