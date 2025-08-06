using UnityEngine;
using UnityEngine.UI;

public class StudyLambda : MonoBehaviour
{
    public delegate void MyDelegate(string s);
    public MyDelegate del;

    public Button btn;

    void Start()
    {

        int a = 10;

        btn.onClick.AddListener(() => ButtonEvent(a));

    }

    private void OnLog(string s)
    {
        Debug.Log("Hello Unity");
    }

    private void ButtonEvent(int a)
    {
        Debug.Log("Button Event");
    }
}