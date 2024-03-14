using System;
using System.Collections.Generic;
using UnityEngine;

public class TrainCaptiveCommand : ITrainCommand
{
    private EnemyType mEnemyType;
    private WeaponType mWeaponType;
    private Vector3 mPosition;
    private int mLv;

    public TrainCaptiveCommand(EnemyType mEnemyType, WeaponType mWeaponType, Vector3 mPosition, int mLv)
    {
        this.mEnemyType = mEnemyType;
        this.mWeaponType = mWeaponType;
        this.mPosition = mPosition;
        this.mLv = mLv;
    }

    public override void Execute()
    {
        IEnemy enemy = null;
        switch (mEnemyType)
        {
            case EnemyType.Elf:
                enemy = FactoryManager.enemyFactory.CreateCharacter<EnemyElf>(mWeaponType, mPosition, mLv) as IEnemy;
                break;
            case EnemyType.Ogre:
                enemy = FactoryManager.enemyFactory.CreateCharacter<EnemyOgre>(mWeaponType, mPosition, mLv) as IEnemy;
                break;
            case EnemyType.Troll:
                enemy = FactoryManager.enemyFactory.CreateCharacter<EnemyTroll>(mWeaponType, mPosition, mLv) as IEnemy;
                break;
            default:
                Debug.Log("无法创建俘兵：" + mEnemyType);
                return;
        }
        GameFacade.Instance.RemoveEnemy(enemy);
        SoldierCaptive captive = new SoldierCaptive(enemy);
        GameFacade.Instance.AddSoldier(captive);
    }
}

