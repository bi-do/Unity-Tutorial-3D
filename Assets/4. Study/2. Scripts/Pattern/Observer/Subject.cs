using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour , ISubject
{
    public List<IObserver> Observers
    {
        get;
        set;
    }

    public void AddObserver(IObserver observer)
    {
        this.Observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        this.Observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (IObserver element in this.Observers)
        {
            element.Notify(1);
        }
    }
}