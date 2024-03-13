using System;
using System.Collections.Generic;
using UnityEngine;

public class NewStageObserverArchievement : IGameEventObserver
{
    private NewStageSubject mSubject;
    private ArchievementSystem mArchSystem;
    public NewStageObserverArchievement(ArchievementSystem mArchSystem)
    {
        this.mArchSystem = mArchSystem;
    }
    public override void SetSubject(IGameEventSubject subject)
    {
        mSubject = subject as NewStageSubject;
    }

    public override void Update()
    {
        mArchSystem.SetMaxStageLv(mSubject.stageCount);
    }
}

