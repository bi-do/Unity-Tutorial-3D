using UnityEngine;

public partial class StudyPartial : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MethodA();
        MethodB();
    }

    private void MethodA()
    {
        Debug.Log("A");
    }
}

public partial class StudyPartial : MonoBehaviour
{

    private void MethodB()
    {
        Debug.Log("B");
    }
}
