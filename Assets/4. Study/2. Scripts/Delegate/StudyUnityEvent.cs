using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

public class StudyUnityEvent : MonoBehaviour
{
    public UnityEvent on_unity_event;

    void Start()
    {
        this.on_unity_event.AddListener(delegate
        {
            Debug.Log("Hello");
            Debug.Log("Unity");
            Debug.Log("World");
            MethodA();

            PrintLog("Hello Unity");
        });
    }

    void OnDisable()
    {
        this.on_unity_event.RemoveListener(this.MethodA);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.on_unity_event?.Invoke();
        }
    }

    public void AddMethod(UnityAction action)
    {
        this.on_unity_event.AddListener(action);
    }

    private void MethodA()
    {
        Debug.Log("Method A");
    }

    private void PrintLog(string msg)
    {
        Debug.Log(msg);
    }
}
