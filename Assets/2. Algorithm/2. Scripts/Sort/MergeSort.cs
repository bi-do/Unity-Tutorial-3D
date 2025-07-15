using UnityEngine;

public class MergeSort : MonoBehaviour
{
    private int[] arr = { 4, 3, 7, 1, 8, 9, 2, 6, 5 };

    void Start()
    {
        Debug.Log($"정렬 전 : {string.Join(", ", arr)}");

        MSort(this.arr, 0, arr.Length - 1);

        Debug.Log($"정렬 후 : {string.Join(", ", arr)}");
    }


    private void MSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;

            MSort(arr, left, mid);
            MSort(arr, mid + 1, right);

            Merge(arr, left, mid, right);
        }
    }

    private void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1; // 왼쪽 배열 크기
        int n2 = right - mid;    // 오른쪽 배열 크기


        int[] left_arr = new int[n1]; // 임시 배열 크기 설정
        int[] right_arr = new int[n2];

        for (int i = 0; i < n1; i++) // 왼쪽 배열 값 초기화
        {
            left_arr[i] = arr[left + i];
        }

        for (int i = 0; i < n2; i++) // 오른쪽 배열 값 초기화
        {
            right_arr[i] = arr[mid + 1 + i];
        }

        int j = left;
        int u = 0;
        int v = 0;

        while (u < n1 && v < n2) // 왼쪽 값이 오른쪽 값보다 작다면
        {
            if (left_arr[u] <= right_arr[v])
            {
                arr[j] = left_arr[u];
                u++;
            }
            else // 오른쪽 값이 왼쪽 값보다 작다면
            {
                arr[j] = right_arr[v];
                v++;
            }
            j++;
        }
        while (u < n1) // 왼쪽 배열이 남았다면
        {
            arr[j] = left_arr[u];
            u++;
            j++;
        }
        while (u < n1) // 오른쪽 배열이 남았다면
        {
            arr[j] = right_arr[v];
            v++;
            j++;
        }

    }

}
