using UnityEngine;

public class InsertionSort : MonoBehaviour
{
    private int[] arr = { 4, 3, 7, 1, 8, 9, 2, 6, 5 };

    void Start()
    {
        Debug.Log($"정렬 전 : {string.Join(", ", arr)}");

        Insertion(this.arr);

        Debug.Log($"정렬 후 : {string.Join(", ", arr)}");
    }

    private void Insertion(int[] param_arr)
    {
        int n = param_arr.Length;

        for (int i = 0; i < n; i++)
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }

            arr[j + 1] = key;
        }
    }

}
