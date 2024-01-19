using System;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyTransition
{
    NullTransition,
    CanAttack,
    LostSoldier
}

public enum EnemyStateID
{
    NullState,
    Chase,
    Attack
}

public abstract class IEnemyState
{
    protected Dictionary<EnemyTransition, EnemyStateID> mMap = new Dictionary<EnemyTransition, EnemyStateID>();
    protected EnemyStateID mStateID;
    protected ICharacter mCharacter;
    protected EnemyFSMSystem mFSM;

    public IEnemyState(EnemyFSMSystem fsm, ICharacter character)
    {
        mFSM = fsm;
        mCharacter = character;
    }
    public EnemyStateID StateID { get { return mStateID; } }

    public void AddTransition(EnemyTransition trans, EnemyStateID id)
    {
        if (trans == EnemyTransition.NullTransition)
        {
            Debug.LogError("EnemyState Error: trans不能为空");
            return;
        }
        if (id == EnemyStateID.NullState)
        {
            Debug.LogError("EnemyState Error: 状态ID不能为空");
            return;
        }
        if (mMap.ContainsKey(trans))
        {
            Debug.LogError("EnemyState Error: [" + trans + "]已经存在");
            return;
        }
        mMap.Add(trans, id);
    }

    public void DeleteTransition(EnemyTransition trans)
    {
        if (!mMap.ContainsKey(trans))
        {
            Debug.LogError("删除转换条件不存在, 转换条件:[" + trans + "]不存在");
            return;
        }
        mMap.Remove(trans);
    }

    public EnemyStateID GetOutPutState(EnemyTransition trans)
    {
        if (!mMap.ContainsKey(trans))
        {
            return EnemyStateID.NullState;
        }
        return mMap[trans];
    }

    public virtual void DoBeforeEntering() { }
    public virtual void DoBeforeLeaving() { }
    public abstract void Reason(List<ICharacter> targets);
    public abstract void Act(List<ICharacter> targets);
}

