using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StudyLinkedList : MonoBehaviour
{
    public LinkedList<int> ints = new LinkedList<int>();

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            ints.AddLast(i);
        }

        ints.AddFirst(100);
        ints.AddLast(500);

        LinkedListNode<int> node_index = ints.AddFirst(1);
        ints.AddBefore(node_index, 200);
        ints.AddAfter(node_index, 500);
    }
}
