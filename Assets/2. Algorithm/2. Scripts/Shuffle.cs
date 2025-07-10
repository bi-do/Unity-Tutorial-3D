using UnityEngine;

public class Shuffle : MonoBehaviour
{
    public int[] arr = new int[10];
    public int shuffle_cnt = 100;

    void Start()
    {
        ShuffleFunc();
    }

    private void ShuffleFunc()
    {
        for (int i = 0; i < this.shuffle_cnt; i++)
        {
            int ran_int_a = Random.Range(0, this.arr.Length);
            int ran_int_b;
            do
            {
                ran_int_b = Random.Range(0, this.arr.Length);
            } while (ran_int_a == ran_int_b);
            Swap(ran_int_a, ran_int_b);
        }

    }

    public void Swap(int param_a, int param_b)
    {
        int temp = this.arr[param_a];
        this.arr[param_a] = this.arr[param_b];
        this.arr[param_b] = temp;
    }
}
