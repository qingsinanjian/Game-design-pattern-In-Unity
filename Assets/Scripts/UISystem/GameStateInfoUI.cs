using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateInfoUI : IBaseUI
{
    private List<GameObject> mHearts;
    private Text mSoldierCount;
    private Text mEnemyCount;
    private Text mCurrentStage;
    private Button mPauseBtn;
    private Button mBackMenuBtn;
    private GameObject mGameOverUI;
    private Text mMessage;
    private Slider mEnergySlider;

    public override void Init()
    {
        base.Init();
        GameObject canvas = UITool.GetCanvas();
        mRootUI = UnityTool.FindChild(canvas, "GameStateUI");

        GameObject heart1 = UnityTool.FindChild(mRootUI, "Heart1");
        GameObject heart2 = UnityTool.FindChild(mRootUI, "Heart2");
        GameObject heart3 = UnityTool.FindChild(mRootUI, "Heart3");
        mHearts = new List<GameObject>();
        mHearts.Add(heart1);
        mHearts.Add(heart2);
        mHearts.Add(heart3);

        mSoldierCount = UITool.FindChild<Text>(mRootUI, "SoldierCount");
        mEnemyCount = UITool.FindChild<Text>(mRootUI, "EnemyCount");
        mCurrentStage = UITool.FindChild<Text>(mRootUI, "StageCount");
        mPauseBtn = UITool.FindChild<Button>(mRootUI, "PauseBtn");
        mBackMenuBtn = UITool.FindChild<Button>(mRootUI, "BackMenuBtn");
        mGameOverUI = UnityTool.FindChild(mRootUI, "GameOver");
        mMessage = UITool.FindChild<Text>(mRootUI, "Message");
        mEnergySlider = UITool.FindChild<Slider>(mRootUI, "EnergySlider");
    }
}
