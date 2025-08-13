using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private Crop crop;
    [SerializeField] private Image slot_img;
    [SerializeField] private Button slot_btn;

    [SerializeField] public bool isEmpty = true;

    void Awake()
    {
        this.slot_btn.onClick.AddListener(UseCrop);
    }

    void OnEnable()
    {
        OnBtnActivate();
    }

    public void AddCrop(Crop crop)
    {
        this.isEmpty = false;

        this.crop = crop;
        this.slot_img.sprite = this.crop.icon;
        OnBtnActivate();
    }

    private void UseCrop()
    {
        if (this.crop != null)
        {
            isEmpty = true;
            this.slot_btn.interactable = false;
            slot_img.gameObject.SetActive(false);
            crop.use_act?.Invoke();
        }
    }

    void OnBtnActivate()
    {
        slot_img.gameObject.SetActive(!isEmpty);
        slot_btn.interactable = !isEmpty;
    }
}