using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;

public class AStar
{
    public static PriorityQueue open_list; // 방문할 수 있는 후보 노드
    public static PriorityQueue closed_list; // 이미 방문한 노드

    private static float HeuristicEstimateCost(Node cur_node, Node end_node)
    {
        Vector3 cost = cur_node.pos - end_node.pos;
        return cost.magnitude;
    }

    public static List<Node> FindPath(Node start_node, Node end_node)
    {
        open_list = new PriorityQueue();
        open_list.Push(start_node);

        start_node.node_total_cost = 0f;
        start_node.estimate_cost = HeuristicEstimateCost(start_node, end_node);
        closed_list = new PriorityQueue();
        Node node = null;

        while (open_list.Length() != 0)
        {
            node = open_list.First();

            if (node.pos == end_node.pos)
            {
                return CalculaterPath(node);
            }

            List<Node> neighbors = new List<Node>();
            GridManager.Instance.GetNeighbors(node, neighbors);

            for(int i = 0; i <neighbors.Count; i++)
            {
                Node neighbor_element = neighbors[i];

                if (!closed_list.Contains(neighbor_element))
                {
                    float cost = HeuristicEstimateCost(node, neighbor_element);

                    // 현재까지 온 값 = G
                    float total_cost = node.node_total_cost + cost;

                    // 현재 이웃노드에서 목적지까지의 추정값 = H
                    float neighbor_node_est_cost = HeuristicEstimateCost(neighbor_element, end_node);

                    neighbor_element.node_total_cost = total_cost;
                    neighbor_element.parent = node;
                    neighbor_element.estimate_cost = total_cost + neighbor_node_est_cost;

                    if (!open_list.Contains(neighbor_element))
                    {
                        open_list.Push(neighbor_element);
                    }
                }
            }
            closed_list.Push(node);
            open_list.Remove(node);
        }

        if (node.pos != end_node.pos)
        {
            Debug.LogError("목적지를 찾지 못했습니다.");
            return null;
        }

        return CalculaterPath(node);
    }

    private static List<Node> CalculaterPath(Node node)
    {
        List<Node> list = new List<Node>();

        while (node != null)
        {
            list.Add(node);
            node = node.parent;
        }

        list.Reverse();

        return list;
    }
}
