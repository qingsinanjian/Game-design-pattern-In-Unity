using System;
using System.Collections.Generic;
using UnityEngine;

public class DM09Observer : MonoBehaviour
{
    private void Start()
    {
        ConcreateSubject1 sub1 = new ConcreateSubject1();
        ConcreateObserver1 ob1 = new ConcreateObserver1(sub1);

        ConcreateObserver2 ob2 = new ConcreateObserver2(sub1);
        sub1.RegisterObserver(ob1);
        sub1.RegisterObserver(ob2);

        sub1.subjectState = "温度 90";
    }
}

public abstract class Subject
{
    List<Observer> observers  = new List<Observer>();

    public void RegisterObserver(Observer ob)
    {
        observers.Add(ob);
    }

    public void RemoveObserver(Observer ob)
    {
        observers.Remove(ob);
    }

    protected void NotifyObserver()
    {
        foreach (Observer ob in observers)
        {
            ob.Update();
        }
    }
}

public class ConcreateSubject1 : Subject
{
    private string mSubjectState;
    public string subjectState
    {
        set
        {
            mSubjectState = value;
            NotifyObserver();
        }
        get { return mSubjectState; }
    }
}

public abstract class Observer
{
    public abstract void Update();
}

public class ConcreateObserver1 : Observer
{
    public ConcreateSubject1 mSub;
    public ConcreateObserver1(ConcreateSubject1 mSub)
    {
        this.mSub = mSub;
    }

    public override void Update()
    {
        Debug.Log("Observer1更新显示" + mSub.subjectState);
    }
}

public class ConcreateObserver2 : Observer
{
    public ConcreateSubject1 mSub;
    public ConcreateObserver2(ConcreateSubject1 mSub)
    {
        this.mSub = mSub;
    }

    public override void Update()
    {
        Debug.Log("Observer2更新显示" + mSub.subjectState);
    }
}

