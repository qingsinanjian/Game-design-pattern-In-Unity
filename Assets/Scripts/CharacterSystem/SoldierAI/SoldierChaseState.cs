using System;
using System.Collections.Generic;
using UnityEngine;

public class SoldierChaseState : ISoldierState
{
    public SoldierChaseState(SoldierFSMSystem fsm, ICharacter character) : base(fsm, character)
    {
        mStateID = SoldierStateID.Chase;
    }

    public override void Act(List<ICharacter> targets)
    {
        if(targets != null && targets.Count > 0)
        {
            mCharacter.MoveTo(targets[0].Position);
        }
    }

    public override void Reason(List<ICharacter> targets)
    {
        if(targets != null && targets.Count > 0)
        {
            mFSM.PerformTransition(SoldierTransition.NoEnemy);
            return;
        }
        float distance = Vector3.Distance(targets[0].Position, mCharacter.Position);
        if(distance < mCharacter.GetAtkRange())
        {
            mFSM.PerformTransition(SoldierTransition.CanAttack);
        }
    }
}

