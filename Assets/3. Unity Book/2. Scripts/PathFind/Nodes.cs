using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Nodes : IComparable<Nodes>
{
    public Node parent;
    public Vector3 pos;

    public float node_total_cost; // G
    public float estimate_cost;  // H

    public bool is_obstacle;
    public Nodes()
    {
        this.parent = null;
        this.node_total_cost = 0;
        this.estimate_cost = 0;
        this.is_obstacle = false;
    }

    public Nodes(Vector3 pos)
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

    public float GetFCost()
    {
        return node_total_cost + estimate_cost;
    }

    public int CompareTo(Nodes node)
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
