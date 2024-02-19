using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacterBuilder
{
    protected ICharacter mCharacter;
    protected System.Type mT;
    protected WeaponType mWeaponType;
    protected Vector3 mSpawnPosition;
    protected int mLv;
    protected string mPrefabName = "";
    public ICharacterBuilder(ICharacter character, Type t, WeaponType weaponType, Vector3 spawnPosition, int lv)
    {
        mCharacter = character;
        this.mT = t;
        this.mWeaponType = weaponType;
        this.mSpawnPosition = spawnPosition;
        this.mLv = lv;
    }

    public abstract void AddCharacterAttr();
    public abstract void AddGameObject();
    public abstract void AddWeapon();
    public abstract ICharacter GetResult();
}

