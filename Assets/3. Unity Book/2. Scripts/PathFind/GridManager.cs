using System;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : Singleton<GridManager>
{
    public GameObject[] obstacles;
    public Node[,] nodes { get; set; }

    public int num_of_rows;
    public int num_of_columns;
    public float gird_cell_size = 1f;

    private Vector3 origin = new Vector3();
    public Vector3 Origin
    {
        get { return origin; }
    }

    protected override void Awake()
    {
        base.Awake();
        this.obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        CalculateObstacles();
    }

    /// <summary> 노드 초기화 및 노드 배열에 장애물 할당 </summary>
    private void CalculateObstacles()
    {
        this.nodes = new Node[num_of_rows, num_of_columns];

        int index = 0;

        for (int i = 0; i < num_of_rows; i++)
        {
            for (int j = 0; j < num_of_columns; j++)
            {
                Vector3 cell_pos = GetGridCellCenter(index);
                Node node = new Node(cell_pos);
                nodes[i, j] = node;
                index++;
            }
        }

        if (obstacles != null && obstacles.Length > 0)
        {
            foreach (GameObject element in obstacles)
            {
                int index_cell = GetGridIndex(element.transform.position);
                int row = GetRow(index_cell);
                int col = GetCol(index_cell);
                nodes[row, col].MakrAsObstacle();
            }
        }
    }

    /// <summary> 해당 인덱스의 노드의 센터 포지션 반환 </summary>
    public Vector3 GetGridCellCenter(int param_index)
    {
        Vector3 cell_pos = GetGridCellPosition(param_index);
        cell_pos.x += gird_cell_size / 2f;
        cell_pos.z += gird_cell_size / 2f;

        return cell_pos;
    }

    public Vector3 GetGridCellPosition(int param_index)
    {
        int row = GetRow(param_index);
        int col = GetCol(param_index);

        float x_pos_in_grid = col * gird_cell_size;
        float y_pos_in_grid = row * gird_cell_size;

        return this.Origin + new Vector3(x_pos_in_grid, 0, y_pos_in_grid);
    }

    /// <summary> 파라미터의 포지션에 넣는 노드의 인덱스 값 반환 </summary>
    public int GetGridIndex(Vector3 param_pos)
    {
        if (!IsInBounds(param_pos))
        {
            return -1;
        }
        else
        {
            param_pos += origin;
            int col = (int)(param_pos.x / gird_cell_size);
            int row = (int)(param_pos.z / gird_cell_size);

            return row * num_of_columns + col;
        }
    }

    public bool IsInBounds(Vector3 param_pos)
    {
        float width = num_of_columns * gird_cell_size;
        float height = num_of_rows * gird_cell_size;

        return param_pos.x >= Origin.x && param_pos.x <= Origin.x + width && param_pos.z >= Origin.z && param_pos.z <= origin.z + height;
    }

    public int GetRow(int param_index)
    {
        return param_index / num_of_columns;
    }

    public int GetCol(int param_index)
    {
        return param_index % num_of_columns;
    }

    public void GetNeighbors(Node param_node, List<Node> param_neighbors)
    {
        int neighbor_index = GetGridIndex(param_node.pos);
        int row = GetRow(neighbor_index);
        int col = GetCol(neighbor_index);

        // 왼쪽
        int left_node_row = row - 1;
        int left_node_col = col;
        AssignNeighbor(left_node_row, left_node_col, param_neighbors);

        // 오른쪽
        left_node_row = row + 1;
        left_node_col = col;
        AssignNeighbor(left_node_row, left_node_col, param_neighbors);

        // 아래
        left_node_row = row;
        left_node_col = col - 1;
        AssignNeighbor(left_node_row, left_node_col, param_neighbors);

        // 위
        left_node_row = row;
        left_node_col = col + 1;
        AssignNeighbor(left_node_row, left_node_col, param_neighbors);
    }

    private void AssignNeighbor(int row, int col, List<Node> param_neighbors)
    {
        if (row != -1 && col != -1 && row < num_of_rows && col < num_of_columns)
        {
            Node node_to_add = this.nodes[row, col];
            if (!node_to_add.is_obstacle)
            {
                param_neighbors.Add(node_to_add);
            }
        }
    }

    void OnDrawGizmos()
    {
        DebugDrawGrid(this.transform.position, this.num_of_rows, this.num_of_columns, this.gird_cell_size, Color.blue);
    }

    public void DebugDrawGrid(Vector3 origin, int num_of_rows, int num_of_columns, float cell_size, Color color)
    {
        float width = num_of_rows * cell_size;
        float height = num_of_columns * cell_size;

        for (int i = 0; i < num_of_rows; i++)
        {
            Vector3 start_pos = origin + i * cell_size * new Vector3(0, 0, 1);
            Vector3 end_pos = start_pos + width * new Vector3(1, 0, 0);
            Debug.DrawLine(start_pos, end_pos, color);
        }

        for (int i = 0; i < num_of_columns; i++)
        {
            Vector3 start_pos = origin + i * cell_size * new Vector3(1, 0, 0);
            Vector3 end_pos = start_pos + height * new Vector3(0, 0, 1);
            Debug.DrawLine(start_pos, end_pos, color);
        }
    }
}
