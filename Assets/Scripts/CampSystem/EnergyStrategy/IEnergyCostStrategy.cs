using System;
using System.Collections.Generic;
using UnityEngine;
//能量消耗策略
public interface IEnergyCostStrategy
{
    public int GetCampUpgradeCost(SoldierType st, int lv);
    public int GetWeaponUpgradeCost(WeaponType wt);
    public int GetSoldierTrainCost(SoldierType st, int lv);

}

