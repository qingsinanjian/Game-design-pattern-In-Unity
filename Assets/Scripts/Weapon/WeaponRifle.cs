using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRifle : IWeapon
{
    public WeaponRifle(int atk, float atkRange, GameObject gameObject) : base(atk, atkRange, gameObject)
    {
    }

    protected override void PlayBulletEffect(Vector3 targetPoisition)
    {
        DoPlayBulletEffect(0.1f, targetPoisition);
    }

    protected override void PlaySound()
    {
        DoPlaySound("RifleShot");
    }

    protected override void SetEffectDisplayTime()
    {
        mEffectDisplayTime = 0.3f;
    }
}
