using UnityEngine;

public class DijkstraSearch : MonoBehaviour
{
    private int[,] nodes = new int[6, 6]{
    //   0  1  2  3  4  5  
        {0 ,1 ,2 ,0 ,4 ,0 },// 0
        {1 ,0 ,0 ,0 ,0 ,8 },// 1
        {2 ,0 ,0 ,3 ,0 ,0 },// 2
        {0 ,0 ,3 ,0 ,0 ,0 },// 3
        {4 ,0 ,0 ,0 ,0 ,2 },// 4
        {0 ,8 ,0 ,0 ,2 ,0 },// 5
        
    };
    void Start()
    {
        int start = 0;
        int[] dist;
        int[] prev;

        Dijkstra(start, out dist, out prev);

        for (int i = 0; i < nodes.GetLength(0); i++)
        {
            Debug.Log($"{start}에서 {i}까지의 최단거리 : {dist[i]}, 경로 : {GetPath(i, prev)}");
        }

    }

    private void Dijkstra(int param_start, out int[] dist, out int[] prev)
    {
        int n = nodes.GetLength(0);
        dist = new int[n];
        prev = new int[n];
        bool[] visited = new bool[n];

        for (int i = 0; i < n; i++)
        {
            dist[i] = int.MaxValue;
            prev[i] = -1;
        }


        dist[param_start] = 0; // 0번 노드에서 시작 ( 시작 노드는 자기 자신과의 거리가 0 )
        for (int i = 0; i < n; i++)
        {
            int u = -1; // 최단거리 노드
            int min = int.MaxValue; // 최소 거리

            // 방문하지 않은 노드 중 최단 거리 노드와 최단 거리 선택
            for (int j = 0; j < n; j++)
            {
                if (!visited[j] && dist[j] < min)
                {
                    min = dist[j];
                    u = j;
                }
            }

            if (u == -1) // 더이상 최단 거리 노드 없음
                break;

            visited[u] = true;

            for (int k = 0; k < n; k++)
            {
                if (nodes[u, k] > 0 && !visited[k])
                {
                    int new_dist = dist[u] + nodes[u, k];
                    if (new_dist < dist[k])
                    {
                        dist[k] = new_dist;
                        prev[k] = u;
                    }
                }
            }
        }

    }

    private string GetPath(int end, int[] prev)
    {
        if (prev[end] == -1)
        {
            return end.ToString();
        }

        return GetPath(prev[end], prev) + "->" + end;
    }

}
