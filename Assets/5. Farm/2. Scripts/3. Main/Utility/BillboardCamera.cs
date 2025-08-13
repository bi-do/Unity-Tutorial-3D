using UnityEngine;

public class BillboardCamera : MonoBehaviour
{
    private Transform main_cam;

    void Start()
    {
        main_cam = Camera.main.transform;
    }

    void LateUpdate()
    {
        this.transform.LookAt(main_cam.transform);
    }
}
