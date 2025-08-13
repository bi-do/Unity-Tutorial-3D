using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private Transform slot_group;
    [SerializeField] private Slot[] slots;
    [SerializeField] private GameObject slot_prefab;

    private int slot_amount = 24;
    private int item_cnt = 0;

    void Start()
    {
        // 게임 시작 시 인벤토리에 Slot 생성
        for (int i = 0; i < this.slot_amount; i++)
        {
            Instantiate(this.slot_prefab, this.slot_group);
        }
        slots = slot_group.GetComponentsInChildren<Slot>();
    }

    public void GetItem(Crop param_crop)
    {
        foreach (Slot element in this.slots)
        {
            if (element.isEmpty)
            {
                element.AddCrop(param_crop);
                this.item_cnt++;
                param_crop.use_act += UseItem;
                break;
            }

        }
    }

    /// <summary> 아이템 사용 시 반드시 호출 ( 아이템 개수 감소 ) </summary>
    public void UseItem()
    {
        item_cnt--;
    }

    /// <summary> 현재 빈 슬롯 유무 여부 확인 </summary>
    public bool CheckItemCount()
    {
        bool result = this.item_cnt < slot_amount;

        return result;
    }
}
