using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKilledObserverAchievement : IGameEventObserver
{
    private AchievementSystem mAchSystem;

    public EnemyKilledObserverAchievement(AchievementSystem achSystem)
    {
        mAchSystem = achSystem;
    }

    public override void SetSubject(IGameEventSubject subject)
    {
        
    }

    public override void Update()
    {
        mAchSystem.AddEnemyKilledCount();
    }
}

