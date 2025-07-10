using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStackManager : MonoBehaviour
{
    public Stack<GameObject> stack_UI = new Stack<GameObject>();

    public Button[] buttons;
    public GameObject[] popup_UIs;

    void Start()
    {
        Init();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject cur_UI = this.stack_UI.Pop();
            cur_UI.SetActive(false);
        }
    }

    public void Init()
    {
        int count = 0;
        foreach (Button element in this.buttons)
        {
            int index = count;
            element.onClick.AddListener(() =>
            {
                if (!popup_UIs[index].activeSelf)
                {
                    popup_UIs[index].SetActive(true);
                    this.stack_UI.Push(popup_UIs[index]);
                }
            });
            count++;
        }
    }
}
