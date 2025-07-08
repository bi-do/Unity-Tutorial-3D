using System.Collections.Generic;
using UnityEngine;

public class StudyQueue : MonoBehaviour
{
    public Queue<int> queue = new Queue<int>();

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            queue.Enqueue(i); // 값 추가
        }

        int output = queue.Dequeue(); // 값 출력
        Debug.Log(output); 

        Debug.Log(queue.Peek()); // 다음 출력 값 확인

        Debug.Log(queue.Contains(5)); // 값 5가 포함되어있는지 확인

        queue.Clear(); // 모든 값 삭제

        Debug.Log(queue.Count); // 값 개수 확인
    }
}
