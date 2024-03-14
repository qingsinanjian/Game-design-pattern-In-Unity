using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesAssetFactory : IAssetFactory
{
    public const string SoldierPath = "Characters/Soldier/";
    public const string EnemyPath = "Characters/Enemy/";
    public const string WeaponPath = "Weapons/";
    public const string EffectPath = "Effects/";
    public const string AudioPath = "Audios/";
    public const string SpritePath = "Sprites/";

    public AudioClip LoadAudioClip(string name)
    {
        return Resources.Load<AudioClip>(AudioPath + name);
    }

    public GameObject LoadEffect(string name)
    {
        return InstantiateGameObject(EffectPath + name);
    }

    public GameObject LoadEnemy(string name)
    {
        return InstantiateGameObject(EnemyPath + name);
    }

    public GameObject LoadSoldier(string name)
    {
        return InstantiateGameObject(SoldierPath + name);
    }

    public Sprite LoadSprite(string name)
    {
        return Resources.Load<Sprite>(SpritePath + name);
    }

    public GameObject LoadWeapon(string name)
    {
        return InstantiateGameObject(WeaponPath + name);
    }

    private GameObject InstantiateGameObject(string path)
    {
        UnityEngine.Object o = Resources.Load(path);
        if(o == null)
        {
            Debug.LogError("无法加载资源，路径：" +  path);
            return null;
        }
        return GameObject.Instantiate(o) as GameObject;
    }

    public UnityEngine.Object LoadAsset(string path)
    {
        UnityEngine.Object o = Resources.Load(path);
        if(o == null)
        {
            Debug.LogError("无法加载资源，路径：" + path);
            return null;
        }
        return o;
    }
}

