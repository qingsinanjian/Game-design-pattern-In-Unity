using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttrStrategy
{
    int GetExtraHPValue(int lv);
    int GetDmgDescValue(int lv);
    int GetCritDmg(float critRate);
}
