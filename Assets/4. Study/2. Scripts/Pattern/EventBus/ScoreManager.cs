using UnityEngine;

namespace Pattern
{
    public class ScoreManager : MonoBehaviour
    {
        private void OnEnable()
        {
            StudyEventBus.on_score_act += UpdateScore;
        }


        private void OnDisable()
        {
            StudyEventBus.on_score_act -= UpdateScore;
        }

        private void UpdateScore(int param_score)
        {
            Debug.Log($"현재 점수 : {param_score}");
        }
    }
}