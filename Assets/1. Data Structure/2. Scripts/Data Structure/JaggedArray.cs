using UnityEngine;

public class JaggedArray : MonoBehaviour
{
    public int[] arr1 = new int[3];
    public int[][] jaggedarr1 = new int[3][];

    void Start()
    {
        arr1[0] = 1;
        arr1[1] = 2;
        arr1[2] = 3;

        jaggedarr1[0] = new int[3] { 1, 2, 3 };
        jaggedarr1[1] = new int[5] { 4, 5, 6, 7, 8 };
        jaggedarr1[2] = new int[2] { 9, 10 };
    }
}
