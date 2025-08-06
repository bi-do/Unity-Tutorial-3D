using UnityEngine;

namespace Pattern
{
    public class ObserverListner : MonoBehaviour, IObserver
    {
        public Subject subject;

        void OnEnable()
        {
            subject.AddObserver(this);
        }

        void OnDisable()
        {
            subject.RemoveObserver(this);
        }
        public void Notify(int param)
        {
            Debug.Log("알림");
        }
    }
}