using System;
using System.Collections.Generic;
using UnityEngine;

public class SoldierKilledObserverAchievement : IGameEventObserver
{
    private AchievementSystem mAchSystem;

    public SoldierKilledObserverAchievement(AchievementSystem mAchSystem)
    {
        this.mAchSystem = mAchSystem;
    }

    public override void SetSubject(IGameEventSubject subject)
    {
        return;
    }

    public override void Update()
    {
        mAchSystem.AddSoldierKilledCount();
    }
}

