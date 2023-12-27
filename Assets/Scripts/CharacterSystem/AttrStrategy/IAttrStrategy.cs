using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttrStrategy
{
    public int GetExtraHPValue(int lv);
    public int GetDmgDescValue(int lv);
    public int GetCritDmg(int critRate);
}
