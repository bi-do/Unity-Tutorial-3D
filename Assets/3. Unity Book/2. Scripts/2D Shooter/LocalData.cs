using UnityEngine;

public class LocalData : MonoBehaviour
{
    private int score;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.score++;
            PlayerPrefs.SetInt("Score", this.score);
            PlayerPrefs.GetInt("Score", this.score);
            PlayerPrefs.SetString("UserName", "John");
            PlayerPrefs.DeleteKey("UserName");
        }
    }
}
