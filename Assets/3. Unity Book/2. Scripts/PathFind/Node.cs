using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Node : IComparable<Node>
{
    public Node parent;
    public Vector3 pos;

    /// <summary> 해당 노드까지 온 비용 </summary>
    public float node_total_cost; // G

    /// <summary> 해당 노드로부터 목적지까지의 추정치 </summary>
    public float estimate_cost;  // H

/// <summary> 장애물 노드인가? </summary>
    public bool is_obstacle;
    public Node()
    {
        this.parent = null;
        this.node_total_cost = 0;
        this.estimate_cost = 0;
        this.is_obstacle = false;
    }

    public Node(Vector3 pos)
    {
        this.pos = pos;
        this.parent = null;
        this.node_total_cost = 0;
        this.estimate_cost = 0;
        this.is_obstacle = false;
    }

    public void MakrAsObstacle()
    {
        this.is_obstacle = true;
    }

    // F = G + H
    public float GetFCost()
    {
        return node_total_cost + estimate_cost;
    }

    public int CompareTo(Node node)
    {
        float my_f = GetFCost();
        float other_f = node.GetFCost();

        if (my_f < other_f)
        {
            return -1;
        }
        else if (my_f > other_f)
        {
            return 1;
        }
        if (estimate_cost < node.estimate_cost)
        {
            return -1;
        }
        else if (estimate_cost > node.estimate_cost)
        {
            return 1;
        }

        return 0;

    }


}
