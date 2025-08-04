using UnityEngine;

public class ExternalClass : MonoBehaviour
{
    public StudyUnityEvent study_event;

    void Awake()
    {
        this.study_event = FindFirstObjectByType<StudyUnityEvent>();
    }

    void Start()
    {
        this.study_event.on_unity_event.AddListener(Event1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.study_event.on_unity_event?.Invoke();
        }
    }

    private void Event1()
    {
        Debug.Log("Event 1");
    }
}
