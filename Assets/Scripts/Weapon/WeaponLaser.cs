using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLaser : IWeapon
{
    public WeaponLaser(int atk, float atkRange, GameObject gameObject) : base(atk, atkRange, gameObject)
    {
    }

    protected override void PlayBulletEffect(Vector3 targetPoisition)
    {
        throw new System.NotImplementedException();
    }

    protected override void PlaySound()
    {
        throw new System.NotImplementedException();
    }

    protected override void SetEffectDisplayTime()
    {
        throw new System.NotImplementedException();
    }
}
