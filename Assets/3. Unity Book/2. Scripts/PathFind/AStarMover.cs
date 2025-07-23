using System.Collections.Generic;
using UnityEngine;

public class AStarMover : MonoBehaviour
{
    private Transform start_tf, end_tf;
    public Node start_node, end_node;

    public List<Node> path_list = new List<Node>();

    public GameObject start_cube, end_cube;

    void Start()
    {
        GetPath();
    }

    void GetPath()
    {
        this.start_tf = this.start_cube.transform;
        this.end_tf = this.end_cube.transform;

        int start_index = GridManager.Instance.GetGridIndex(start_tf.position);
        int start_row = GridManager.Instance.GetRow(start_index);
        int start_col = GridManager.Instance.GetCol(start_index);
        this.start_node = GridManager.Instance.nodes[start_row, start_col];

        int end_index = GridManager.Instance.GetGridIndex(end_tf.position);
        int end_row = GridManager.Instance.GetRow(end_index);
        int end_col = GridManager.Instance.GetCol(end_index);
        this.end_node = GridManager.Instance.nodes[end_row, end_col];

        path_list = AStar.FindPath(start_node, end_node);
    }

    void OnDrawGizmos()
    {
        if (path_list == null)
            return;


        if (path_list.Count > 0)
        {
            int index = 1;
            foreach (Node element in path_list)
            {
                if (index < path_list.Count)
                {
                    Node next_node = path_list[index];
                    Debug.DrawLine(element.pos, next_node.pos, Color.green);
                    Debug.Log($"현재 노드 : {element.pos.x} , {element.pos.z} , 다음 노드 : {next_node.pos.x} , {next_node.pos.z})");
                    index++;
                }
            }
        }
    }
}
