using UnityEngine;
using UnityEngine.EventSystems;

public class UIHandler : MonoBehaviour , IDragHandler , IPointerDownHandler
{
    private RectTransform inventory_tf;

    private Vector2 base_pos;
    private Vector2 start_pos;
    private Vector2 move_offset;

    void Awake()
    {
        this.inventory_tf = this.transform.parent.GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.move_offset = (eventData.position - start_pos);
        this.inventory_tf.anchoredPosition = base_pos + move_offset;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        inventory_tf.SetAsLastSibling();
        base_pos = inventory_tf.anchoredPosition;
        start_pos = eventData.position;
    }
}
