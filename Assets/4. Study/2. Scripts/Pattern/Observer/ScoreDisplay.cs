using TMPro;
using UnityEngine;
namespace Pattern
{
    public class ScoreDisplay : MonoBehaviour, IObserver
    {
        public ISubject subject;
        public TextMeshProUGUI score_UI;

        void OnEnable()
        {
            subject.AddObserver(this);
        }

        void OnDisable()
        {
            subject.RemoveObserver(this);
        }

        public void Notify(int score)
        {
            this.score_UI.text = score.ToString();
        }
    }
}