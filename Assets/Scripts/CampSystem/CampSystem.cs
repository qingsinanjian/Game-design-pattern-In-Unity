using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampSystem : IGameSystem
{
    private Dictionary<SoldierType, SoldierCamp> mSoldierCamps = new Dictionary<SoldierType, SoldierCamp>();

    public override void Init()
    {
        base.Init();
        InitCamp(SoldierType.Rookie);
        InitCamp(SoldierType.Sergeant);
        InitCamp(SoldierType.Captain);
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
                name = "新手兵营";
                icon = "RookieCamp";
                trainTime = 3f;
                break;
            case SoldierType.Sergeant:
                gameObjectName = "SoldierCamp_Sergeant";
                name = "中士兵营";
                icon = "SergeantCamp";
                trainTime = 4f;
                break;
            case SoldierType.Captain:
                gameObjectName = "SoldierCamp_Captain";
                name = "上尉兵营";
                icon = "CaptainCamp";
                trainTime = 5f;
                break;
            default:
                Debug.LogError($"无法根据战士类型{soldierType}初始化兵营");
                break;
        }
        gameObject = GameObject.Find(gameObjectName);
        position = UnityTool.FindChild(gameObject, "TrainPoint").transform.position;
        SoldierCamp soldierCamp = new SoldierCamp(gameObject, name, icon, soldierType, position, trainTime);

        CampOnClick campOnClick = gameObject.AddComponent<CampOnClick>();
        campOnClick.camp = soldierCamp;

        mSoldierCamps.Add(soldierType, soldierCamp);
    }

    public override void Update()
    {
        foreach (SoldierCamp camp in mSoldierCamps.Values)
        {
            camp.Update();
        }
    }
}
