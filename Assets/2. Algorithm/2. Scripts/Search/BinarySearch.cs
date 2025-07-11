using UnityEngine;

public class BinarySearch : MonoBehaviour
{

    private int[] array = new int[10];
    private int target = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Init();

        int result_index = BSearch();
    }

    private void Init()
    {
        for (int i = 0; i < array.Length; i++)
        {
            this.array[i] = i + 1;
        }
    }

    private int BSearch()
    {
        int left = 0;
        int right = this.array.Length - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (target > array[mid])
            {
                left = mid + 1;
            }
            else if (target < array[mid])
            {
                right = mid - 1;
            }
            else if (target == array[mid])
            {
                Debug.Log($"찾고 있는 거 {mid + 1}번째");
                return mid;
            }
        }
        Debug.Log("찾고있는거 없어요");

        return -1;
    }
}
