using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGun :IWeapon
{
    public override void Fire(Vector3 targetPosition)
    {
        Debug.Log("��ʾ��Ч Gun");
        Debug.Log("�������� Gun");
    }
}
