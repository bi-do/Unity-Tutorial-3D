using TMPro;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    public TextMeshProUGUI cur_score_UI;
    public TextMeshProUGUI best_score_UI;

    private int cur_score = 0;
    private int best_score = 0;

    public int Score
    {
        get { return cur_score; }
        set
        {
            cur_score = value;
            SetScoreUI();
        }
    }

    protected override void Awake()
    {
        base.Awake();
        this.best_score = PlayerPrefs.GetInt("2D_Shooter_BestScore", 0);
        this.best_score_UI.text = $"최고 점수 : {this.best_score}";
    }

    public void SetScoreUI()
    {
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
