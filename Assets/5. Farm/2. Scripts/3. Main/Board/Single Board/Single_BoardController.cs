using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Single_BoardController : MonoBehaviour
{
    [SerializeField] private GameObject cell_prefab;
    [SerializeField] private Transform cell_group;
    [SerializeField] private TextMeshProUGUI status_txt;
    [SerializeField] private Button restart_btn;

    private Single_BoardTicTacToe game_board;
    private Single_Cell[,] cells = new Single_Cell[3, 3];

    public static Action start_game_act;

    void Awake()
    {
        restart_btn.onClick.AddListener(StartGame);
    }

    void OnEnable()
    {
        start_game_act += StartGame;
    }

    void OnDisable()
    {
        start_game_act -= StartGame;
    }

    private void StartGame()
    {
        game_board = new Single_BoardTicTacToe();
        status_txt.text = "Player X Turn";
        restart_btn.gameObject.SetActive(false);

        // 셀 초기화 및 생성
        for (int i = 0; i < cell_group.childCount; i++)
        {
            Destroy(cell_group.GetChild(i).gameObject);
        }
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject cell_obj = Instantiate(cell_prefab, cell_group);
                Single_Cell cell = cell_obj.GetComponent<Single_Cell>();

                cell.SetButton(i, j, OnCellClicked);
                cells[i, j] = cell;
            }
        }
    }

    private void OnCellClicked(int x, int y)
    {
        if (game_board.IsGameOver() || game_board.board[x, y] != 0)
        {
            return;
        }

        Single_Move move = new Single_Move(x, y, game_board.player);
        game_board.MakeMove(move);

        BoardVisualUpdate();
        CheckForGameOver();
    }

    private void BoardVisualUpdate()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                string str = "";
                if (game_board.board[i, j] == 1)
                {
                    str = "X";
                }
                else if (game_board.board[i, j] == 2)
                {
                    str = "O";
                }

                cells[i, j].SetText(str);
            }
        }
    }

    private void CheckForGameOver()
    {
        int winner = game_board.CheckWinner();
        if (winner == 0)
        {
            string next_player = game_board.player == 1 ? "X" : "O";
            this.status_txt.text = $"Player : {next_player} Turn";
            return;
        }

        if (winner == 3)
        {
            status_txt.text = "Draw";
        }
        else
        {
            string result = winner == 1 ? "X" : "O";
            status_txt.text = $"Player {result} Win";
        }

        this.restart_btn.gameObject.SetActive(true);
    }
}
