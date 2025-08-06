using System;
using UnityEngine;

public class StudyPredicate : MonoBehaviour
{
    public Predicate<int> my_predicate;

    public int level = 10;


    void Start()
    {
        my_predicate = (int n) => n <= 10;
        string msg = my_predicate(this.level) ? "초보자 사냥터 입장 가능" : "초보자 사냥터 입장 불가능";

        Debug.Log(msg);
    }

    // 람다 풀어쓴 뜻
    public string CheckLog(int n)
    {
        string result = "";
        if (level <= 10)
        {
            result = "초보자 사냥터 입장 가능";
        }
        else
        {
            result = "초보자 사냥터 입장 불가능";
        }

        return result;
    }
    

    // private void LevelCheck(int level)
    // {
    //     if (level <= 10)
    //     {
    //         Debug.Log("초보자 사냥터 입장 가능");
    //     }
    //     else
    //     {
    //         Debug.Log("초보자 사냥터 입장 불가능");
    //     }
    // }
}