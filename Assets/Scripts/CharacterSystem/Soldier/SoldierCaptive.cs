using System;
using System.Collections.Generic;
using UnityEngine;

public class SoldierCaptive : ISoldier
{
    private IEnemy mEnemy;
    public SoldierCaptive(IEnemy mEnemy)
    {
        this.mEnemy = mEnemy;
        ICharacterAttr attr = new SoldierAttr(mEnemy.attr.attrStrategy, 1, mEnemy.attr.baseAttr);
        this.attr = attr;
        this.gameObject = mEnemy.gameObject;
        this.weapon = mEnemy.weapon;
    }

    protected override void PlayEffect()
    {
        mEnemy.PlayEffect();
    }

    protected override void PlaySound()
    {
        //DoNothing
    }
}

