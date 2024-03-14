using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICharacterAttr
{
    protected CharacterBaseAttr mBaseAttr;
    protected int mLv;
    protected int mCurrentHP;
    protected int mDmgDescValue;

    public ICharacterAttr(IAttrStrategy strategy, int lv, CharacterBaseAttr baseAttr)
    {
        mStrategy = strategy;
        mLv = lv;
        mBaseAttr = baseAttr;
        mDmgDescValue = mStrategy.GetDmgDescValue(mLv);
        mCurrentHP = baseAttr.maxHP + mStrategy.GetExtraHPValue(mLv);
    }
    //���ӵ����Ѫ�� �������˺�ֵ �������ӵ��˺�

    protected IAttrStrategy mStrategy;
    public IAttrStrategy attrStrategy { get { return mStrategy; } }
    public CharacterBaseAttr baseAttr { get { return mBaseAttr; } }

    public int critValue
    {
        get { return mStrategy.GetCritDmg(mBaseAttr.critRate); }
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
