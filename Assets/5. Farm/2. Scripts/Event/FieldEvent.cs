using UnityEngine;

public class FieldEvent : MonoBehaviour
{
    private int cam_index = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Farm.GameManager.Instance.SetCamState(CamState.Field);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Farm.GameManager.Instance.SetCamState(CamState.Outside);

        }
    }
}
