using System.Collections.Generic;
using UnityEngine;

public class DynamicArray : MonoBehaviour
{
    [SerializeField] List<int> ints = new List<int>(){ 1, 2, 3 };

    void Start()
    {
        ints.Add(10); // 리스트 추가

        for (int i = 0; i < 10; i++)
        {
            ints.Add(i);
        }

        // ints.Insert(0, 3);

        // ints.Remove(5); // 값 5 제거

        // ints.RemoveAt(5); // 5번 인덱스 제거

        // ints.RemoveRange(1, 3); // 1 ~ 3번 인덱스 제거

        // ints.Clear(); // 데이터 모두 제거

        // ints.RemoveAll(x => x > 5 && x < 9); // 조건 제거

        // ints.Sort(); // 오름차순 정렬


        // string str = string.Empty;
        // foreach (int element in ints)
        // {
        //     str +=  element + "/";
        // }
        // Debug.Log(str);

        if (ints.Contains(10)) // 10 이 컨테이너 안에 포함될 시 True
        {
            Debug.Log("10 존재");
        }
        else
        {
            Debug.Log("10 없음");
        }
    }
    
    // private object[] array = new object[3];

    // void Add(object param_o)
    // {
    //     int new_size = array.Length * 2;
    //     object[] temp = new object[new_size];

    //     int count = 0;
    //     foreach (object element in array)
    //     {
    //         temp[count] = element;
    //         count++;
    //     }

    //     array = temp;
    //     array[array.Length - 1] = param_o; 

    // }
}
