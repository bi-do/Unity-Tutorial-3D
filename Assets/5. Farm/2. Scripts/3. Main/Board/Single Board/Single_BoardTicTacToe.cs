using System.Collections.Generic;
using UnityEngine;

public class Single_BoardTicTacToe
{
    public int[,] board;
    private const int ROWS = 3, COLS = 3;

    public int player;

    public Single_BoardTicTacToe()
    {
        player = 1;
        board = new int[COLS, ROWS];
    }

    /// <summary> 남아있는 칸 확인 </summary>
    public List<Single_Move> GetMoves()
    {
        List<Single_Move> moves = new List<Single_Move>();

        for (int i = 0; i < ROWS; i++)
        {
            for (int j = 0; j < COLS; j++)
            {
                if (this.board[i, j] == 0)
                {
                    moves.Add(new Single_Move(i, j, player));
                }
            }
        }
        return moves;
    }

    /// <summary> 칸 선택시 호출 </summary>
    public void MakeMove(Single_Move param_move)
    {
        if (board[param_move.x, param_move.y] != 0)
            return;

        board[param_move.x, param_move.y] = param_move.player;

        this.player = param_move.player == 1 ? 2 : 1;
    }

    /// <summary> 0 : 진행중 , (1,2) : Player N 승리 , 3 : 무승부 </summary>
    public int CheckWinner()
    {
        // 행 확인
        for (int i = 0; i < ROWS; i++)
        {

            if (board[i, 0] != 0 && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
            {
                return board[i, 0];
            }
        }

        // 열 확인
        for (int j = 0; j < COLS; j++)
        {
            if (board[0, j] != 0 && board[0, j] == board[1, j] && board[1, j] == board[2, j])
            {
                return board[0, j];
            }
        }

        // 대각선 확인
        if (board[0, 0] != 0 && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
        {
            return board[0, 0];
        }
        if (board[0, 2] != 0 && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
        {
            return board[0, 2];
        }

        if (GetMoves().Count == 0)
            return 3;

        return 0;
    }

    public bool IsGameOver()
    {
        return CheckWinner() != 0;
    }


}
