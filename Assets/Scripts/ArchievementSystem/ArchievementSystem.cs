using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchievementSystem : IGameSystem
{
    private int mEnemyKilledCount = 0;
    private int mSoldierKilledCount = 0;
    private int mMaxStageLv = 1;

    public override void Init()
    {
        base.Init();
        mFacade.RegisterObserver(GameEventType.EnemyKilled, new EnemyKilledObserverArchievement(this));
        mFacade.RegisterObserver(GameEventType.SoldierKilled, new SoldierKilledObserverArchievement(this));
        mFacade.RegisterObserver(GameEventType.NewStage, new NewStageObserverArchievement(this));
    }

    public void AddEnemyKilledCount(int number = 1)
    {
        mEnemyKilledCount += number;
        Debug.Log("EnemyKilledCount" + mEnemyKilledCount);
    }

    public void AddSoldierKilledCount(int number = 1)
    {
        mSoldierKilledCount += number;
        Debug.Log("SoldierKilledCount" + mSoldierKilledCount);
    }

    public void SetMaxStageLv(int stageLv)
    {
        if(stageLv > mMaxStageLv)
        {
            mMaxStageLv = stageLv;
        }
        Debug.Log("MaxStageLv" + mMaxStageLv);
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("EnemyKilledCount", mEnemyKilledCount);
        PlayerPrefs.SetInt("SoldierKilledCount", mSoldierKilledCount);
        PlayerPrefs.SetInt("MaxStageLv", mMaxStageLv);
    }

    private void LoadData()
    {
        mEnemyKilledCount = PlayerPrefs.GetInt("EnemyKilledCount");
        mSoldierKilledCount = PlayerPrefs.GetInt("SoldierKilledCount");
        mMaxStageLv = PlayerPrefs.GetInt("MaxStageLv");
    }
}
