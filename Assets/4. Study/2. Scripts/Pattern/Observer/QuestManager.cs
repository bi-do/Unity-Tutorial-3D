using UnityEngine;

namespace Pattern
{
    public class QuestManager : MonoBehaviour, IObserver
    {
        private bool is_quest_clear1 = false;
        private bool is_quest_clear2 = false;
        private bool is_quest_clear3 = false;

        public ISubject subject;

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
            if (score >= 100 && !is_quest_clear1)
            {
                this.is_quest_clear1 = true;
                Debug.Log("100점 달성");
            }
            else if (score >= 500 && !is_quest_clear2)
            {
                is_quest_clear2 = true;
                Debug.Log("500점 달성");

            }
            else if (score >= 1000 && is_quest_clear3)
            {
                is_quest_clear3 = true;
                Debug.Log("1000점 달성");
            }
        }
    }
}