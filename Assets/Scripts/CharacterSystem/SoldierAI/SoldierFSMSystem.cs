using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierFSMSystem
{
    private List<ISoldierState> mStates = new List<ISoldierState>();
    private ISoldierState mCurrentState;
    public ISoldierState currentState {  get { return mCurrentState; } }
    public void AddState(ISoldierState state)
    {
        if(state == null)
        {
            Debug.LogError("Ҫ��ӵ�״̬Ϊ��" + state.StateID);
            return;
        }
        if(mStates.Count == 0)
        {
            mStates.Add(state);
            mCurrentState = state;
            return;
        }
        foreach (ISoldierState s in mStates)
        {
            if(s.StateID == state.StateID)
            {
                Debug.LogError("Ҫ��ӵ�״̬ID��[" + state.StateID + "]�Ѿ����");
                return;
            }
        }
        mStates.Add(state);
    }

    public void AddState(params ISoldierState[] state)
    {
        foreach (ISoldierState s in state)
        {
            AddState(s);
        }
    }

    public void DeleteState(SoldierStateID stateID)
    {
        if(stateID == SoldierStateID.NullState)
        {
            Debug.LogError("Ҫɾ����״̬IDΪ��" + stateID);
            return;
        }
        foreach (ISoldierState s in mStates)
        {
            if(s.StateID == stateID)
            {
                mStates.Remove(s);
                return;
            }
        }
        Debug.LogError("Ҫɾ����StateID��[" + stateID + "]�����ڼ�����");
    }

    public void PerformTransition(SoldierTransition trans)
    {
        if(trans == SoldierTransition.NullTransition)
        {
            Debug.LogError("Ҫִ�е�ת������Ϊ�գ�" + trans);
            return;
        }
        SoldierStateID nextStateID = mCurrentState.GetOutPutState(trans);
        if(nextStateID == SoldierStateID.NullState)
        {
            Debug.LogError("��ת��������" + trans + "��û�ж�Ӧ��ת��״̬");
            return;
        }
        foreach(ISoldierState s in mStates)
        {
            if(s.StateID == nextStateID)
            {
                mCurrentState.DoBeforeLeaving();
                mCurrentState = s;
                mCurrentState.DoBeforeEntering();
                return;
            }
        }
    }
}
