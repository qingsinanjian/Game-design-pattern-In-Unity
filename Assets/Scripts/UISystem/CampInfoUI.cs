using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CampInfoUI : IBaseUI
{
    private Image mCampIcon;
    private Text mCampName;
    private Text mCampLevel;
    private Text mWeaponLevel;
    private Button mCampUpgradeBtn;
    private Button mWeaponUpgradeBtn;
    private Button mTrainBtn;
    private Button mCancelTrainBtn;
    private Text mAliveCount;
    private Text mTrainingCount;
    private Text mTrainTime;

    private ICamp mCamp;

    public override void Init()
    {
        base.Init();
        GameObject canvas = UITool.GetCanvas();
        mRootUI = UnityTool.FindChild(canvas, "CampInfoUI");

        mCampIcon = UITool.FindChild<Image>(mRootUI, "CampIcon");
        mCampName = UITool.FindChild<Text>(mRootUI, "CampName");
        mCampLevel = UITool.FindChild<Text>(mRootUI, "CampLv");
        mWeaponLevel = UITool.FindChild<Text>(mRootUI, "WeaponLv");
        mCampUpgradeBtn = UITool.FindChild<Button>(mRootUI, "CampUpgradeBtn");
        mWeaponUpgradeBtn = UITool.FindChild<Button>(mRootUI, "WeaponUpgradeBtn");
        mTrainBtn = UITool.FindChild<Button>(mRootUI, "TrainBtn");
        mCancelTrainBtn = UITool.FindChild<Button>(mRootUI, "CancelTrainBtn");
        mAliveCount = UITool.FindChild<Text>(mRootUI, "AliveCount");
        mTrainingCount = UITool.FindChild<Text>(mRootUI, "TrainingCount");
        mTrainTime = UITool.FindChild<Text>(mRootUI, "TrainTime");

        mTrainBtn.onClick.AddListener(OnTrainClick);
        mCancelTrainBtn.onClick.AddListener(OnCancelTrainClick);
        mCampUpgradeBtn.onClick.AddListener(OnCampUpgradeClick);
        mWeaponUpgradeBtn.onClick.AddListener(OnWeaponUpgradeClick);

        Hide();
    }

    public override void Update()
    {
        base.Update();
        if(mCamp != null)
        {
            ShowTrainingInfo();
        }
    }

    public void ShowCampInfo(ICamp camp)
    {
        Show();
        mCamp = camp;

        mCampIcon.sprite = FactoryManager.assetFactory.LoadSprite(camp.iconSprite);
        mCampName.text = camp.name;
        mCampLevel.text = camp.lv.ToString();
        ShowWeaponType(camp.weaponType);

        ShowTrainingInfo();
    }

    private void ShowTrainingInfo()
    {
        mTrainingCount.text = mCamp.trainCount.ToString();
        mTrainTime.text = mCamp.trainRemainingTime.ToString("0.00");
        if (mCamp.trainCount == 0)
        {
            mCancelTrainBtn.interactable = false;
        }
        else
        {
            mCancelTrainBtn.interactable = true;
        }
    }

    private void ShowWeaponType(WeaponType type)
    {
        switch (type)
        {
            case WeaponType.Gun:
                mWeaponLevel.text = "短枪";
                break;
            case WeaponType.Rifle:
                mWeaponLevel.text = "长枪";
                break;
            case WeaponType.Rocket:
                mWeaponLevel.text = "火箭";
                break;
            case WeaponType.MAX:
                break;
            default:
                break;
        }
    }

    public void OnTrainClick()
    {
        //能量是否足够 TODO
        mCamp.Train();
    }

    public void OnCancelTrainClick()
    {
        //回收能量 TODO
        mCamp.CancelTrainCommand();
    }

    private void OnCampUpgradeClick()
    {
        int energy = mCamp.energyCostCampUpgrade;
        if (energy < 0)
        {
            //TODO
            return;
        }
        //TODO
        mCamp.UpgradeCamp();
        ShowCampInfo(mCamp);
    }

    private void OnWeaponUpgradeClick()
    {
        int energy = mCamp.energyCostWeaponUpgrade;
        if(energy < 0)
        {
            //TODO
            return;
        }
        //TODO
        mCamp.UpgradeWeapon();
        ShowCampInfo(mCamp);
    }
}
