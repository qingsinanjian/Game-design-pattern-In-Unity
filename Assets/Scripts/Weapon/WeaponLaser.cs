using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLaser : IWeapon
{
    public override void Fire(Vector3 targetPoisition)
    {
        Debug.Log("��ʾ��Ч Laser");
        Debug.Log("�������� Laser");
    }
}
