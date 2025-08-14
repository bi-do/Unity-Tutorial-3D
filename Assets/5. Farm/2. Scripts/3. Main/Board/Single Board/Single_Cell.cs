using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Single_Cell : MonoBehaviour
{
    /// <summary> 행렬 인덱스 </summary>
    public int x, y;
    [SerializeField] private Button btn_UI;
    [SerializeField] private TextMeshProUGUI text_UI;

    public void SetText(string param_text)
    {
        this.text_UI.text = param_text;
    }

    public void SetButton(int x, int y, Action<int, int> act)
    {
        this.x = x;
        this.y = y;

        btn_UI.onClick.AddListener(() => act(this.x, this.y));
    }

}
