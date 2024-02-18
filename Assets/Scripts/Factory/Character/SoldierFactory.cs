﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class SoldierFactory : ICharacterFactory
{
    public ICharacter CreateCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1) where T : ICharacter, new()
    {
        ICharacter character = new T();

        string name = "";
        int maxHP = 0;
        float moveSpeed = 0;

        string iconSprite = "";
        string prefabName = "";

        Type t = typeof(T);
        if(t == typeof(SoldierCaptain))
        {
            name = "上尉士兵";
            maxHP = 100;
            moveSpeed = 3;
            iconSprite = "CaptainIcon";
            prefabName = "Soldier1";
        }
        else if(t == typeof(SoldierSergeant))
        {
            name = "中士士兵";
            maxHP = 90;
            moveSpeed = 3;
            iconSprite = "SergeantIcon";
            prefabName = "Soldier3";
        }
        else if (t == typeof(SoldierRookie))
        {
            name = "新手士兵";
            maxHP = 80;
            moveSpeed = 2.5f;
            iconSprite = "RookieIcon";
            prefabName = "Soldier2";
        }
        else
        {
            Debug.LogError($"类型{t}不属于Soldier，无法创建战士");
            return null;
        }

        ICharacterAttr attr = new SoldierAttr(new SoldierAttrStrategy(), name, maxHP, moveSpeed, iconSprite, prefabName);
        character.attr = attr;

        //创建角色
        //1.加载 2.实例化
        GameObject characterGO = FactoryManager.assetFactory.LoadSoldier(prefabName);
        characterGO.transform.position = spawnPosition;
        character.gameObject = characterGO;

        //添加武器
        IWeapon weapon = FactoryManager.weaponFactory.CreateWeapon(weaponType);
        character.weapon = weapon;
        return character;
    }
}

