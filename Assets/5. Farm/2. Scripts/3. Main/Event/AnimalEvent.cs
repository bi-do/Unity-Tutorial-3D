using UnityEngine;

public class AnimalEvent : MonoBehaviour
{
    private int cam_index = 3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Farm.GameManager.Instance.SetCamState(CamState.Animal);

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
