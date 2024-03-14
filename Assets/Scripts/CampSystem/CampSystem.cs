using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampSystem : IGameSystem
{
    private Dictionary<SoldierType, SoldierCamp> mSoldierCamps = new Dictionary<SoldierType, SoldierCamp>();
    private Dictionary<EnemyType, CaptiveCamp> mCaptiveCamps = new Dictionary<EnemyType, CaptiveCamp>();

    public override void Init()
    {
        base.Init();
        InitCamp(SoldierType.Rookie);
        InitCamp(SoldierType.Sergeant);
        InitCamp(SoldierType.Captain);

        InitCamp(EnemyType.Elf);
    }

    private void InitCamp(SoldierType soldierType)
    {
        GameObject gameObject = null;
        string gameObjectName = null;
        string name = null;
        string icon = null;
        Vector3 position = Vector3.zero;
        float trainTime = 0.0f;
        switch (soldierType)
        {
            case SoldierType.Rookie:
                gameObjectName = "SoldierCamp_Rookie";
                name = "���ֱ�Ӫ";
                icon = "RookieCamp";
                trainTime = 3f;
                break;
            case SoldierType.Sergeant:
                gameObjectName = "SoldierCamp_Sergeant";
                name = "��ʿ��Ӫ";
                icon = "SergeantCamp";
                trainTime = 4f;
                break;
            case SoldierType.Captain:
                gameObjectName = "SoldierCamp_Captain";
                name = "��ξ��Ӫ";
                icon = "CaptainCamp";
                trainTime = 5f;
                break;
            default:
                Debug.LogError($"�޷�����սʿ����{soldierType}��ʼ����Ӫ");
                break;
        }
        gameObject = GameObject.Find(gameObjectName);
        position = UnityTool.FindChild(gameObject, "TrainPoint").transform.position;
        SoldierCamp soldierCamp = new SoldierCamp(gameObject, name, icon, soldierType, position, trainTime);

        CampOnClick campOnClick = gameObject.AddComponent<CampOnClick>();
        campOnClick.camp = soldierCamp;

        mSoldierCamps.Add(soldierType, soldierCamp);
    }

    private void InitCamp(EnemyType enemyType)
    {
        GameObject gameObject = null;
        string gameObjectName = null;
        string name = null;
        string icon = null;
        Vector3 position = Vector3.zero;
        float trainTime = 0.0f;
        switch (enemyType)
        {
            case EnemyType.Elf:
                gameObjectName = "CaptiveCamp_Elf";
                name = "����Ӫ";
                icon = "CaptiveCamp";
                trainTime = 3f;
                break;
            default:
                Debug.LogError($"�޷����ݵ�������{enemyType}��ʼ����Ӫ");
                break;
        }
        gameObject = GameObject.Find(gameObjectName);
        position = UnityTool.FindChild(gameObject, "TrainPoint").transform.position;
        CaptiveCamp captiveCamp = new CaptiveCamp(gameObject, name, icon, enemyType, position, trainTime);
        CampOnClick campOnClick = gameObject.AddComponent<CampOnClick>();
        campOnClick.camp = captiveCamp;

        mCaptiveCamps.Add(enemyType, captiveCamp);
    }

    public override void Update()
    {
        foreach (SoldierCamp camp in mSoldierCamps.Values)
        {
            camp.Update();
        }

        foreach (CaptiveCamp camp in mCaptiveCamps.Values)
        {
            camp.Update();
        }
    }
}
