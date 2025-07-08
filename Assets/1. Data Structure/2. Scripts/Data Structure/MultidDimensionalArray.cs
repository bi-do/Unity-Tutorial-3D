using UnityEngine;

public class MultidDimensionalArray : MonoBehaviour
{
    public int[,] array1 = new int[3, 3];
    public int[,,] array2 = new int[3, 3, 3];


    void Start()
    {
        int number1 = array1[0, 0];
        int number2 = array1[1, 0];
        int num3 = array1[2, 0];
    }
}