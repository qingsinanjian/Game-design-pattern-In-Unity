using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGun : IWeapon
{
    public WeaponGun(int atk, float atkRange, GameObject gameObject) : base(atk, atkRange, gameObject)
    {
    }

    protected override void PlayBulletEffect(Vector3 targetPoisition)
    {
        DoPlayBulletEffect(0.05f, targetPoisition);
    }

    protected override void PlaySound()
    {
        DoPlaySound("GunShot");
    }

    protected override void SetEffectDisplayTime()
    {
        mEffectDisplayTime = 0.2f;
    }
}
