using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI cur_score_UI;
    public TextMeshProUGUI best_score_UI;

    private int cur_score = 0;
    private int best_score = 0;

    void Awake()
    {
        this.best_score = PlayerPrefs.GetInt("2D_Shooter_BestScore", 0);
        this.best_score_UI.text = $"최고 점수 : {this.best_score}";
    }

    public void AddScore(int value)
    {
        cur_score += value;
        this.cur_score_UI.text = $"현재 점수 : {this.cur_score}";

        if (this.best_score < this.cur_score)
        {
            this.best_score = this.cur_score;
            this.best_score_UI.text = $"최고 점수 : {this.best_score}";
            PlayerPrefs.SetInt("2D_Shooter_BestScore", this.best_score);
        }
    }

    public int GetScore()
    {
        return cur_score;
    }
    

}
