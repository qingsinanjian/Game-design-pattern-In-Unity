﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SoldierBuilder : ICharacterBuilder
{
    public SoldierBuilder(ICharacter character, Type t, WeaponType weaponType, Vector3 spawnPosition, int lv) : base(character, t, weaponType, spawnPosition, lv)
    {
    }

    public override void AddCharacterAttr()
    {
        string name = "";
        int maxHP = 0;
        float moveSpeed = 0;

        string iconSprite = "";

        if (mT == typeof(SoldierCaptain))
        {
            name = "上尉士兵";
            maxHP = 100;
            moveSpeed = 3;
            iconSprite = "CaptainIcon";
            mPrefabName = "Soldier1";
        }
        else if (mT == typeof(SoldierSergeant))
        {
            name = "中士士兵";
            maxHP = 90;
            moveSpeed = 3;
            iconSprite = "SergeantIcon";
            mPrefabName = "Soldier3";
        }
        else if (mT == typeof(SoldierRookie))
        {
            name = "新手士兵";
            maxHP = 80;
            moveSpeed = 2.5f;
            iconSprite = "RookieIcon";
            mPrefabName = "Soldier2";
        }
        else
        {
            Debug.LogError($"类型{mT}不属于Soldier，无法创建战士");
        }

        ICharacterAttr attr = new SoldierAttr(new SoldierAttrStrategy(), mLv, name, maxHP, moveSpeed, iconSprite, mPrefabName);
        mCharacter.attr = attr;
    }

    public override void AddGameObject()
    {
        //创建角色
        //1.加载 2.实例化
        GameObject characterGO = FactoryManager.assetFactory.LoadSoldier(mPrefabName);
        characterGO.transform.position = mSpawnPosition;
        mCharacter.gameObject = characterGO;
    }

    public override void AddWeapon()
    {
        //添加武器
        IWeapon weapon = FactoryManager.weaponFactory.CreateWeapon(mWeaponType);
        mCharacter.weapon = weapon;
    }

    public override ICharacter GetResult()
    {
        return mCharacter;
    }
}

