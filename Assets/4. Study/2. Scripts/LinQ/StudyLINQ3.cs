using UnityEngine;
using System.Linq;


public class StudyLINQ3 : MonoBehaviour
{
    public int[] nums = { 1, 2, 3, 4, 5, 6 };

    void Start()
    {
        // var result = from num in nums
        //              where num > 1
        //              //  orderby num         // 오름차순
        //              orderby num descending // 내림차순
        //              select num;

        var result = nums.Where(n => n > 1).OrderByDescending(n => n);

        foreach (int element in result)
        {
            Debug.Log(element);
        }
    }
}