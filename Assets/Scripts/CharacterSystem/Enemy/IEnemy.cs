using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Elf,
    Ogre,
    Troll
}

public abstract class IEnemy : ICharacter
{
    protected EnemyFSMSystem mFSMSystem;

    public IEnemy()
    {
        MakeFSM();
    }

    private void MakeFSM()
    {
        mFSMSystem = new EnemyFSMSystem();
        EnemyChaseState chaseState = new EnemyChaseState(mFSMSystem, this);
        chaseState.AddTransition(EnemyTransition.CanAttack, EnemyStateID.Attack);

        EnemyAttackState attackState = new EnemyAttackState(mFSMSystem, this);
        attackState.AddTransition(EnemyTransition.LostSoldier, EnemyStateID.Chase);
        mFSMSystem.AddState(chaseState, attackState);
    }

    public override void UpdateFSMAI(List<ICharacter> targets)
    {
        if (mIsKilled) return;
        mFSMSystem.currentState.Act(targets);
        mFSMSystem.currentState.Reason(targets);
    }

    public override void RunVisitor(ICharacterVisitor visitor)
    {
        visitor.VisitEnemy(this);
    }

    public override void UnderAttack(int damage)
    {
        if(mIsKilled) return;
        base.UnderAttack(damage);
        PlayEffect();
        if(mAttr.currentHP <= 0)
        {
            Killed();
        }
    }

    public override void Killed()
    {
        base.Killed();
        GameFacade.Instance.NotifySubject(GameEventType.EnemyKilled);
    }

    public abstract void PlayEffect();
}
