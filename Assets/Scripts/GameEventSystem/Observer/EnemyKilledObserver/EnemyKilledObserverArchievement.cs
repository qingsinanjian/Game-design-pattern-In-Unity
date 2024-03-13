using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKilledObserverArchievement : IGameEventObserver
{
    private ArchievementSystem mArchSystem;

    public EnemyKilledObserverArchievement(ArchievementSystem archSystem)
    {
        mArchSystem = archSystem;
    }

    public override void SetSubject(IGameEventSubject subject)
    {
        
    }

    public override void Update()
    {
        mArchSystem.AddEnemyKilledCount();
    }
}

