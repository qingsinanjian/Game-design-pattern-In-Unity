using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttr : ICharacterAttr
{
    public EnemyAttr(IAttrStrategy strategy, int lv, string name, int maxHP, float moveSpeed, string iconSprite, string prefabName) : base(strategy, lv, name, maxHP, moveSpeed, iconSprite, prefabName)
    {
    }
}
