using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesAssetProxyFactory : IAssetFactory
{
    private ResourcesAssetFactory mAssetFactory = new ResourcesAssetFactory();
    private Dictionary<string, GameObject> mSoldiers = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mEnemys = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mWeapons = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mEffects = new Dictionary<string, GameObject>();
    private Dictionary<string, AudioClip> mAudioClips = new Dictionary<string, AudioClip>();
    private Dictionary<string, Sprite> mSprites = new Dictionary<string, Sprite>();


    public AudioClip LoadAudioClip(string name)
    {
        if (mAudioClips.ContainsKey(name))
        {
            return mAudioClips[name];
        }
        else
        {
            AudioClip clip = mAssetFactory.LoadAudioClip(name);
            mAudioClips.Add(name, clip);
            return clip;
        }
    }

    public GameObject LoadEffect(string name)
    {
        if (mEffects.ContainsKey(name))
        {
            return GameObject.Instantiate(mEffects[name]);
        }
        else
        {
            GameObject go = mAssetFactory.LoadAsset(ResourcesAssetFactory.EffectPath + name) as GameObject;
            mEffects.Add(name, go);
            return GameObject.Instantiate(go);
        }
    }

    public GameObject LoadEnemy(string name)
    {
        if (mEnemys.ContainsKey(name))
        {
            return GameObject.Instantiate(mEnemys[name]);
        }
        else
        {
            GameObject go = mAssetFactory.LoadAsset(ResourcesAssetFactory.EnemyPath + name) as GameObject;
            mEnemys.Add(name, go);
            return GameObject.Instantiate(go);
        }
    }

    public GameObject LoadSoldier(string name)
    {
        if (mSoldiers.ContainsKey(name))
        {
            return GameObject.Instantiate(mSoldiers[name]);
        }
        else
        {
            GameObject go = mAssetFactory.LoadAsset(ResourcesAssetFactory.SoldierPath + name) as GameObject;
            mSoldiers.Add(name, go);
            return GameObject.Instantiate(go);
        }
    }

    public Sprite LoadSprite(string name)
    {
        if (mSprites.ContainsKey(name))
        {
            return mSprites[name];
        }
        else
        {
            Sprite sp = mAssetFactory.LoadSprite(name);
            mSprites.Add(name, sp);
            return sp;
        }
    }

    public GameObject LoadWeapon(string name)
    {
        if (mWeapons.ContainsKey(name))
        {
            return GameObject.Instantiate(mWeapons[name]);
        }
        else
        {
            GameObject go = mAssetFactory.LoadAsset(ResourcesAssetFactory.WeaponPath + name) as GameObject;
            mWeapons.Add(name, go);
            return GameObject.Instantiate(go);
        }
    }
}

