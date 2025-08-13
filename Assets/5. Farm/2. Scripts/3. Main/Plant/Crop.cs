using System;
using UnityEngine;

public class Crop : MonoBehaviour
{
    [SerializeField] private string crop_name;
    public Sprite icon;

    /// <summary> 작물 사용 시점에 호출되는 액션 </summary>
    public Action use_act;

    void Start()
    {
        use_act += Use;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Get();
        }
    }

    public void Get()
    {
        if (Farm.GameManager.Instance.item.CheckItemCount())
        {
            Farm.GameManager.Instance.item.GetItem(this);
            Debug.Log($"{this.crop_name} 획득");
            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("아이템 인벤토리 공간 부족");
        }
    }

    public void Use()
    {
        Debug.Log($"{crop_name}을 사용했습니다.");
    }
}
