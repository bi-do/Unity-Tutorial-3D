using UnityEngine;

public class Permutation : MonoBehaviour
{
    public int[] arr = new int[3] { 1, 2, 3, };

    void Start()
    {
        PermutationFunc(this.arr, 0);
    }

    private void PermutationFunc(int[] param_arr, int start)
    {
        if (start == arr.Length)
        {
            Debug.Log(string.Join(", ", arr));
            return;
        }

        for (int i = start; i < arr.Length; i++)
        {
            // Swap
            int temp = arr[start];
            arr[start] = arr[i];
            arr[i] = temp;

            PermutationFunc(arr, start + 1); // 재귀

            // 원상복구 BackTracking
            temp = arr[start];
            arr[start] = arr[i];
            arr[i] = temp;
        }
    }
}
