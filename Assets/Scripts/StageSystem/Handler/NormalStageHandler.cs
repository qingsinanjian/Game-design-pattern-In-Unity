﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class NormalStageHandler : IStageHandler
{
    private EnemyType mEnemyType;
    private WeaponType mWeaponType;
    private int mCount;
    private Vector3 mPosition;

    private int mSpawnTime = 1;
    private float mSpawnTimer = 0;
    private int mCountSpawned = 0;

    public NormalStageHandler(StageSystem stageSystem, int lv, EnemyType et, WeaponType wt, int count, Vector3 pos, int countToFinished) : base(stageSystem, lv, countToFinished)
    {
        mEnemyType = et;
        mWeaponType = wt;
        mCount = count;
        mPosition = pos;
        mSpawnTimer = mSpawnTime;
    }

    protected override void UpdateStage()
    {
        base.UpdateStage();
        if(mCountSpawned < mCount)
        {
            mSpawnTimer -= Time.deltaTime;
            if(mSpawnTimer <= 0)
            {
                SpawnEnemy();
                mSpawnTimer = mSpawnTime;
            }
        }
    }

    private void SpawnEnemy()
    {
        mCountSpawned++;
        switch (mEnemyType)
        {
            case EnemyType.Elf:
                FactoryManager.enemyFactory.CreateCharacter<EnemyElf>(mWeaponType, mPosition);
                break;
            case EnemyType.Ogre:
                FactoryManager.enemyFactory.CreateCharacter<EnemyOgre>(mWeaponType, mPosition);
                break;
            case EnemyType.Troll:
                FactoryManager.enemyFactory.CreateCharacter<EnemyTroll>(mWeaponType, mPosition);
                break;
            default:
                Debug.LogError($"无法生成敌人，敌人类型为：{mEnemyType}");
                break;
        }
    }
}

