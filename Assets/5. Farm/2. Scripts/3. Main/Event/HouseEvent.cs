using UnityEngine;

public class HouseEvent : MonoBehaviour
{
    [SerializeField] private GameObject house_top;            // 지붕 오브젝트

    private int cam_index = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           Farm.GameManager.Instance.SetCamState(CamState.House);
            this.house_top.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
             Farm.GameManager.Instance.SetCamState(CamState.Outside);
            this.house_top.SetActive(true);
        }
    }
}
