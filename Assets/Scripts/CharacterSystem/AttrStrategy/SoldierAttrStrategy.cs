using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttrStrategy : IAttrStrategy
{
    public int GetCritDmg(int critRate)
    {
        return 0;
    }

    public int GetCritDmg(float critRate)
    {
        throw new System.NotImplementedException();
    }

    public int GetDmgDescValue(int lv)
    {
        return (lv - 1) * 5;
    }

    public int GetExtraHPValue(int lv)
    {
        return (lv - 1) * 10;
    }
}
