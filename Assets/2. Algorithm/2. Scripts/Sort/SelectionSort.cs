using System.Linq;
using UnityEngine;

public class SelectionSort : MonoBehaviour
{
    private int[] arr = { 4, 3, 7, 1, 8, 9, 2, 6, 5 };


    void Start()
    {
        Debug.Log($"정렬 전 : {string.Join(", ", arr)}");

        Selection(this.arr);

        Debug.Log($"정렬 후 : {string.Join(", ", arr)}");
    }

    private void Selection(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++)
        {
            int min_index = i;
            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[min_index])
                {
                    min_index = j;
                }
            }
            if (i != min_index)
            {
                int temp = arr[min_index];
                arr[min_index] = arr[i];
                arr[i] = temp;
            }
        }
    }
}
