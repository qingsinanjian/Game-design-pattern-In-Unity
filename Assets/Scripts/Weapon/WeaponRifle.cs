using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRifle : IWeapon
{
    public override void Fire(Vector3 targetPosition)
    {
        Debug.Log("��ʾ��Ч Rifle");
        Debug.Log("�������� Rifle");
    }
}
