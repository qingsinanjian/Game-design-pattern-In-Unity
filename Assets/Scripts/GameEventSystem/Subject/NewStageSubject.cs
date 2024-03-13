using System;
using System.Collections.Generic;
using UnityEngine;

public class NewStageSubject : IGameEventSubject
{
    private int mStageCount = 1;
    public int stageCount
    {
        get { return mStageCount; }
    }

    public override void Notify()
    {
        mStageCount++;
        base.Notify();
    }
}

