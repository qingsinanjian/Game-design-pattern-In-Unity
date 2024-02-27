using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRocket : IWeapon
{
    public WeaponRocket(WeaponBaseAttr baseAttr, GameObject gameObject) : base(baseAttr, gameObject)
    {
    }

    protected override void PlayBulletEffect(Vector3 targetPoisition)
    {
        DoPlayBulletEffect(0.3f, targetPoisition);
    }

    protected override void PlaySound()
    {
        DoPlaySound("RocketShot");
    }

    protected override void SetEffectDisplayTime()
    {
        mEffectDisplayTime = 0.4f;
    }
}
