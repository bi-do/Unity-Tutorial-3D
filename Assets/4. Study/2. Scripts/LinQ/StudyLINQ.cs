using Unity.Collections;
using UnityEngine;
using System.Linq;

public class StudyLINQ : MonoBehaviour
{
    public int[] numbers = { 1, 2, 3, 4, 5 };

    void Start()
    {
        // var result = from num in numbers
        //              where num > 3
        //              select num;

        var result = numbers.Where(num => num > 3).Select(num => num * num);

        foreach (int element in result)
        {
            Debug.Log(element);
        }

    }
}
