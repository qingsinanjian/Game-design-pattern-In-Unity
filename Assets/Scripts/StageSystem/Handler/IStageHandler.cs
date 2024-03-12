using System;
using System.Collections.Generic;
using UnityEngine;

public class IStageHandler
{
    protected int mLv;
    protected IStageHandler mNextHandler;
    private int mCountToFinished;
    protected StageSystem mStageSystem;
    public IStageHandler(StageSystem stageSystem, int lv, int countToFinished)
    {
        mStageSystem = stageSystem;
        mLv = lv;
        mCountToFinished = countToFinished;
    }

    public IStageHandler SetNextHandler(IStageHandler handler)
    {
        mNextHandler = handler;
        return handler;
    }
    public void Handle(int level)
    {
        if(level == mLv)
        {
            UpdateStage();
            CheckIsFinished();
        }
        else
        {
            mNextHandler.Handle(level);
        }
    }

    protected virtual void UpdateStage() { }
    private void CheckIsFinished()
    {
        if(mStageSystem.GetCountOfEnemyKilled() >= mCountToFinished)
        {
            mStageSystem.EnterNextStage();
        }
    }
}

