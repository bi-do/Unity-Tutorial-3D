using System;
using UnityEngine;

public class BoardEvent : MonoBehaviour
{
    [SerializeField] private GameObject board_UI;
    [SerializeField] private GameObject AI_board_UI;
    [SerializeField] private GameObject select_board_UI;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            select_board_UI.SetActive(true);
            Single_BoardController.start_game_act?.Invoke();
            BoardController.start_game_act?.Invoke();

            Farm.GameManager.Instance.SetCamState(CamState.Board);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            select_board_UI.SetActive(false);
            AI_board_UI.SetActive(false);
            board_UI.SetActive(false);
            Farm.GameManager.Instance.SetCamState(CamState.House);
        }
    }
}
