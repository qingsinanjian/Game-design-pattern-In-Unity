using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBaseAttr
{
    protected string mName;
    protected int mMaxHP;
    protected float mMoveSpeed;
    protected string mIconSprite;
    protected string mPrefabName;
    protected float mCritRate;//暴击率0-1

    public CharacterBaseAttr(string name, int maxHP, float moveSpeed, string iconSprite, string prefabName, float critRate)
    {
        this.mName = name;
        this.mMaxHP = maxHP;
        this.mMoveSpeed = moveSpeed;
        this.mIconSprite = iconSprite;
        this.mPrefabName = prefabName;
        this.mCritRate = critRate;
    }

    public string name
    {
        get
        {
            return mName;
        }
    }

    public int maxHP
    {
        get
        {
            return mMaxHP;
        }
    }

    public float moveSpeed
    {
        get
        {
            return mMoveSpeed;
        }
    }

    public string iconSprite
    {
        get
        {
            return mIconSprite;
        }
    }

    public string prefabName
    {
        get
        {
            return mPrefabName;
        }
    }

    public float critRate
    {
        get
        {
            return mCritRate;
        }
    }
}

