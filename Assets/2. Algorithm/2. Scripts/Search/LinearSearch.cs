using UnityEngine;

public class LinearSearch : MonoBehaviour
{
    private int[] array = new int[10];
    public int search_value;

    void Start()
    {
        Init();

        LSearch(this.array, this.search_value);
    }

    private void Init()
    {
        for (int i = 0; i < array.Length; i++)
        {
            this.array[i] = i + 1;
        }
    }

    private void LSearch(int[] arr, int param_search_value)
    {
        int count = 1;
        foreach (int element in this.array)
        {
            if (element == param_search_value)
            {
                Debug.Log($"{param_search_value}은 {count}번째에 있습니다.");
                break;
            }
            else
                count++;
        }
    }

}
