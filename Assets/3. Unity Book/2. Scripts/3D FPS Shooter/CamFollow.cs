using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        this.transform.position = target.position;
    }
}
