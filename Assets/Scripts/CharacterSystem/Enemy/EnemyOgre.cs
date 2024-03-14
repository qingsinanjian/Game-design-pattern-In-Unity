using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOgre : IEnemy
{
    public override void PlayEffect()
    {
        DoPlayEffect("OgreHitEffect");
    }
}
