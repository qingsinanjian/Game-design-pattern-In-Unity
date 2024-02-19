using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICharacterAttr
{
    protected string mName;
    protected int mMaxHP;
    protected float mMoveSpeed;

    protected int mCurrentHP;
    protected string mIconSprite;
    protected string mPrefabName;

    protected int mLv;
    protected float mCritRate;//暴击率0-1
    protected int mDmgDescValue;

    public ICharacterAttr(IAttrStrategy strategy, int lv, string name, int maxHP, float moveSpeed, string iconSprite, string prefabName)
    {
        mStrategy = strategy;
        mLv = lv;
        mName = name;
        mMaxHP = maxHP;
        mMoveSpeed = moveSpeed;
        mIconSprite = iconSprite;
        mPrefabName = prefabName;

        mDmgDescValue = mStrategy.GetDmgDescValue(mLv);
        mCurrentHP = mMaxHP + mStrategy.GetExtraHPValue(mLv);
    }
    //增加的最大血量 抵御的伤害值 暴击增加的伤害

    protected IAttrStrategy mStrategy;

    public int critValue
    {
        get { return mStrategy.GetCritDmg(mCritRate); }
    }

    public int dmgDescValue
    {
        get { return mDmgDescValue; }
    }

    public int currentHP
    {
        get { return mCurrentHP; }
    }

    public void TakeDamage(int damage)
    {
        damage -= dmgDescValue;
        mCurrentHP -= damage;
    }
}
