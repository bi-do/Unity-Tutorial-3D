using System.Collections.Generic;
using UnityEngine;

public class StudyStack : MonoBehaviour
{
    public Stack<int> stack = new Stack<int>();

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            stack.Push(i); // 스택에 푸시
        }
        Debug.Log(stack.Pop()); // 스텍에서 팝 ( 데이터 출력 )
        Debug.Log(stack.Count);

        Debug.Log(stack.Peek()); // 다음에 뽑을 값 확인
        Debug.Log(stack.Count);

        Debug.Log(stack.Pop()); // 스텍에서 팝 ( 데이터 출력 )
        Debug.Log(stack.Count);
    }

}
