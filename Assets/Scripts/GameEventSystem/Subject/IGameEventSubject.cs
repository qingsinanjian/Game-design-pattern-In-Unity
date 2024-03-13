using System;
using System.Collections.Generic;
using UnityEngine;

public class IGameEventSubject
{
    private List<IGameEventObserver> mObservers = new List<IGameEventObserver>();

    public void RegisterObserver(IGameEventObserver ob)
    {
        mObservers.Add(ob);
    }

    public void RemoveObserver(IGameEventObserver ob)
    {
        mObservers.Remove(ob);
    }

    public virtual void Notify()
    {
        foreach (var ob in mObservers)
        {
            ob.Update();
        }
    }
}

