﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class AchievementMemento
{
    public int enemyKilledCount { get; set; }
    public int soldierKilledCount { get; set; }
    public int maxStageLv {  get; set; }

    public void SaveData()
    {
        PlayerPrefs.SetInt("EnemyKilledCount", enemyKilledCount);
        PlayerPrefs.SetInt("SoldierKilledCount", soldierKilledCount);
        PlayerPrefs.SetInt("MaxStageLv", maxStageLv);
    }

    public void LoadData()
    {
        enemyKilledCount = PlayerPrefs.GetInt("EnemyKilledCount");
        soldierKilledCount = PlayerPrefs.GetInt("SoldierKilledCount");
        maxStageLv = PlayerPrefs.GetInt("MaxStageLv");
    }
}

