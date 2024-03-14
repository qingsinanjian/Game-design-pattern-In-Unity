using System;
using System.Collections.Generic;
using UnityEngine;

public class CaptiveCamp : ICamp
{
    private WeaponType mWeaponType = WeaponType.Gun;
    private EnemyType mEnemyType;
    public CaptiveCamp(GameObject gameObject, string name, string icon, EnemyType enemyType, Vector3 position, float trainTime, WeaponType weaponType = WeaponType.Gun, int lv = 1)
        : base(gameObject, name, icon, SoldierType.Captive, position, trainTime)
    {
        mEnemyType = enemyType;
        mEnergyCostStrategy = new SoldierEnergyCostStrategy();
        UpdateEnergyCost();
    }
    public override int lv
    {
        get { return 1; }
    }

    public override WeaponType weaponType
    {
        get { return mWeaponType; }
    }
    public override int energyCostCampUpgrade
    {
        get { return 0; }
    }

    public override int energyCostWeaponUpgrade
    {
        get { return 0; }
    }

    public override int energyCostTrain
    {
        get { return mEnergyCostTrain; }
    }

    public override void Train()
    {
        TrainCaptiveCommand cmd = new TrainCaptiveCommand(mEnemyType, mWeaponType, mPosition, lv);
        mCommands.Add(cmd);
    }

    public override void UpgradeCamp()
    {
        
    }

    public override void UpgradeWeapon()
    {
        
    }

    protected override void UpdateEnergyCost()
    {
        mEnergyCostTrain = mEnergyCostStrategy.GetSoldierTrainCost(mSoldierType, 1);
    }
}

