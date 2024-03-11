using System;
using System.Collections.Generic;
using UnityEngine;

public static class FactoryManager
{
    private static IAssetFactory mAssetFactory = null;
    private static SoldierFactory mSoldierFactory = null;
    private static EnemyFactory mEnemyFactory = null;
    private static IWeaponFactory mWeaponFactory = null;
    private static IAttrFactory mAttrFactory = null;

    public static IAssetFactory assetFactory
    {
        get
        {
            if(mAssetFactory == null)
            {
                mAssetFactory = new ResourcesAssetFactory();
            }
            return mAssetFactory;
        }
    }

    public static SoldierFactory soldierFactory
    {
        get
        {
            if(mSoldierFactory == null)
            {
                mSoldierFactory = new SoldierFactory();
            }
            return mSoldierFactory;
        }
    }

    public static EnemyFactory enemyFactory
    {
        get
        {
            if (mEnemyFactory == null)
            {
                mEnemyFactory = new EnemyFactory();
            }
            return mEnemyFactory;
        }
    }

    public static IWeaponFactory weaponFactory
    {
        get
        {
            if(mWeaponFactory == null)
            {
                mWeaponFactory = new WeaponFactory();
            }
            return mWeaponFactory;
        }
    }

    public static IAttrFactory attrFactory
    {
        get
        {
            if (mAttrFactory == null)
            {
                mAttrFactory = new AttrFactory();
            }
            return mAttrFactory;
        }
    }
}

