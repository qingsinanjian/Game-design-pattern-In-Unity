using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLaser : IWeapon
{
    public override void Fire(Vector3 targetPoisition)
    {
        Debug.Log("显示特效 Laser");
        Debug.Log("播放声音 Laser");
    }
}
