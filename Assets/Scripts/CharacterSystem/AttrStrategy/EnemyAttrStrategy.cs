using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttrStrategy : IAttrStrategy
{
    public int GetCritDmg(int critRate)
    {
        int value = Random.Range(0, 1);
        int critDmg = 0;
        if(value < critRate)
        {
            critDmg = (int)Random.Range(0.5f, 1f) * 10;
        }
        return critDmg;
    }

    public int GetDmgDescValue(int lv)
    {
        return 0;
    }

    public int GetExtraHPValue(int lv)
    {
        return 0;
    }
}
