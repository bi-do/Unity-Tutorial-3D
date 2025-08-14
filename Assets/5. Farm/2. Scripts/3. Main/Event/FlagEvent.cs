using UnityEngine;

public class FlagEvent : MonoBehaviour
{
    private Vector3 offset_pos = new Vector3(-0.015f, 0.48f, -0.367f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.transform.SetParent(other.transform);
            this.transform.localPosition = offset_pos;
            this.transform.localRotation = Quaternion.identity;
        }
    }
}
