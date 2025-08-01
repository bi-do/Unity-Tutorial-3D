using UnityEngine;

public class StudyStatic : MonoBehaviour
{
    void Start()
    {
        // Debug.Log($"정적 변수에 접근 : {StaticClass.num}");
    }
}

public class StaticClass
{
    public static StaticClass instance = new StaticClass();
    public static int num = 10;

    public StaticClass()
    {
        Debug.Log($"생성자 실행 : {num}");
    }
}
