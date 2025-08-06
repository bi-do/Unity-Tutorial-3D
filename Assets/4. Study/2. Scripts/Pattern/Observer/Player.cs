using System.Collections.Generic;
using UnityEngine;

namespace Pattern.Observer
{
    public class Player : MonoBehaviour, ISubject
    {
        private int score;
        public int Scroe
        {
            get
            {
                return score;
            }
            set
            {
                this.score = value;
                NotifyObservers();
            }
        }

        public List<IObserver> Observers { get; set; }

        public void AddObserver(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            Observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (IObserver element in this.Observers)
            {
                element.Notify(this.score);
            }
        }
    }

}