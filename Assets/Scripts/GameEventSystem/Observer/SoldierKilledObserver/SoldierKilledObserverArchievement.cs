using System;
using System.Collections.Generic;
using UnityEngine;

public class SoldierKilledObserverArchievement : IGameEventObserver
{
    private ArchievementSystem mArchSystem;

    public SoldierKilledObserverArchievement(ArchievementSystem mArchSystem)
    {
        this.mArchSystem = mArchSystem;
    }

    public override void SetSubject(IGameEventSubject subject)
    {
        return;
    }

    public override void Update()
    {
        mArchSystem.AddSoldierKilledCount();
    }
}

