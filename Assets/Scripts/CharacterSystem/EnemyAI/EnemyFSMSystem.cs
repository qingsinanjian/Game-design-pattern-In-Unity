using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSMSystem
{
    private List<IEnemyState> mStates = new List<IEnemyState>();
    private IEnemyState mCurrentState;
    public IEnemyState currentState { get { return mCurrentState; } }
    public void AddState(IEnemyState state)
    {
        if (state == null)
        {
            Debug.LogError("要添加的状态为空" + state.StateID);
            return;
        }
        if (mStates.Count == 0)
        {
            mStates.Add(state);
            mCurrentState = state;
            mCurrentState.DoBeforeEntering();
            return;
        }
        foreach (IEnemyState s in mStates)
        {
            if (s.StateID == state.StateID)
            {
                Debug.LogError("要添加的状态ID：[" + state.StateID + "]已经添加");
                return;
            }
        }
        mStates.Add(state);
    }

    public void AddState(params IEnemyState[] state)
    {
        foreach (IEnemyState s in state)
        {
            AddState(s);
        }
    }

    public void DeleteState(EnemyStateID stateID)
    {
        if (stateID == EnemyStateID.NullState)
        {
            Debug.LogError("要删除的状态ID为空" + stateID);
            return;
        }
        foreach (IEnemyState s in mStates)
        {
            if (s.StateID == stateID)
            {
                mStates.Remove(s);
                return;
            }
        }
        Debug.LogError("要删除的StateID：[" + stateID + "]不存在集合中");
    }

    public void PerformTransition(EnemyTransition trans)
    {
        if (trans == EnemyTransition.NullTransition)
        {
            Debug.LogError("要执行的转换条件为空：" + trans);
            return;
        }
        EnemyStateID nextStateID = mCurrentState.GetOutPutState(trans);
        if (nextStateID == EnemyStateID.NullState)
        {
            Debug.LogError("在转换条件：" + trans + "下没有对应的转换状态");
            return;
        }
        foreach (IEnemyState s in mStates)
        {
            if (s.StateID == nextStateID)
            {
                mCurrentState.DoBeforeLeaving();
                mCurrentState = s;
                mCurrentState.DoBeforeEntering();
                return;
            }
        }
    }
}

