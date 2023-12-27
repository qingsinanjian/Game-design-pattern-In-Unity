using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGun :IWeapon
{
    public override void Fire(Vector3 targetPosition)
    {
        Debug.Log("显示特效 Gun");
        Debug.Log("播放声音 Gun");
    }
}
