using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState :IEnemyState
{
    public EnemyChaseState(EnemyFSMSystem fsm, ICharacter character) : base(fsm, character)
    {
        mStateID = EnemyStateID.Chase;
    }

    private Vector3 mTargetPosition;

    public override void DoBeforeEntering()
    {
        mTargetPosition = GameFacade.Instance.GetEnemyTargetPosition();
    }

    public override void DoBeforeLeaving()
    {
        base.DoBeforeLeaving();
    }

    public override void Act(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            mCharacter.MoveTo(targets[0].Position);
        }
        else
        {
            mCharacter.MoveTo(mTargetPosition);
        }
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            float distance = Vector3.Distance(mCharacter.Position, targets[0].Position);
            if(distance <= mCharacter.GetAtkRange())
            {
                mFSM.PerformTransition(EnemyTransition.CanAttack);
            }
        }
    }
}

