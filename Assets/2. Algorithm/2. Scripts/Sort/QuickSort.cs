using UnityEngine;

public class QuickSort : MonoBehaviour
{
    private int[] arr = { 4, 3, 7, 1, 8, 9, 2, 6, 5 };

    void Start()
    {
        Debug.Log($"정렬 전 : {string.Join(", ", arr)}");

        Quick(this.arr, 0, arr.Length - 1);

        Debug.Log($"정렬 후 : {string.Join(", ", arr)}");
    }

    private void Quick(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(arr, left, right);

            Quick(arr, left, pivot - 1);
            Quick(arr, pivot + 1, right);
        }
    }

    private int Partition(int[] arr, int left, int right)
    {
        int pivot = arr[right];
        int index = left - 1;

        for (int i = left; i < right; i++)
        {
            if (arr[i] < pivot)
            {
                index++;

                int temp = arr[i];
                arr[i] = arr[index];
                arr[index] = temp;
            }
        }

        int temp2 = arr[index + 1];
        arr[index + 1] = arr[right];
        arr[right] = temp2;

        return index + 1;
    }

}
