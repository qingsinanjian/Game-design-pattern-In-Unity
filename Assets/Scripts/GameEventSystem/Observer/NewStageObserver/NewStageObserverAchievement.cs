using System;
using System.Collections.Generic;
using UnityEngine;

public class NewStageObserverAchievement : IGameEventObserver
{
    private NewStageSubject mSubject;
    private AchievementSystem mAchSystem;
    public NewStageObserverAchievement(AchievementSystem mAchSystem)
    {
        this.mAchSystem = mAchSystem;
    }
    public override void SetSubject(IGameEventSubject subject)
    {
        mSubject = subject as NewStageSubject;
    }

    public override void Update()
    {
        mAchSystem.SetMaxStageLv(mSubject.stageCount);
    }
}

