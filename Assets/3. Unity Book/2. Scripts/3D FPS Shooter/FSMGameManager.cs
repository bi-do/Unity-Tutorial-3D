using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPSGameManager : Singleton<FPSGameManager>
{
    public enum GameState { Ready, Run, Pause, GameOver }
    public GameState gState;

    public GameObject gameLabel;
    public GameObject game_option_UI;
    private TextMeshProUGUI gameText;

    private FPSPlayerMove player;

    void Start()
    {
        this.gState = GameState.Ready;
        this.gameText = gameLabel.GetComponent<TextMeshProUGUI>();

        gameText.text = "Ready...";
        gameText.color = new Color32(255, 185, 0, 255);

        player = GameObject.Find("Player").GetComponent<FPSPlayerMove>();

        StartCoroutine(ReadyToStart()); // Ready -> Run으로 전환되는 코루틴
    }

    void Update()
    {
        if (player.hp <= 0)
        {
            player.GetComponentInChildren<Animator>().SetFloat("MoveMotion", 0f);

            gameLabel.SetActive(true);
            gameText.text = "Game Over";
            gameText.color = new Color32(255, 0, 0, 255);

            Transform buttons = gameText.transform.GetChild(0);

            buttons.gameObject.SetActive(true);

            gState = GameState.GameOver;
        }
    }

    IEnumerator ReadyToStart()
    {
        yield return new WaitForSeconds(2f); // 2초 대기
        gameText.text = "Go!"; // 텍스트 변경

        yield return new WaitForSeconds(0.5f);
        gameLabel.SetActive(false);
        gState = GameState.Run; // 상태 전환
    }

    public void OpenOptionWindow()
    {
        this.game_option_UI.SetActive(true);
        Time.timeScale = 0f; // 게임 씬 정지 , UI 상호작용은 가능  , Scene Load와 연관 X
        this.gState = GameState.Pause;
    }

    public void CloseOptionWindow()
    {
        this.game_option_UI.SetActive(false);
        Time.timeScale = 1f; // 게임 씬 정지 , UI 상호작용은 가능
        this.gState = GameState.Pause;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}