using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRocket : IWeapon
{
    public override void Fire(Vector3 targetPosition)
    {
        Debug.Log("��ʾ��Ч Rocket");
        Debug.Log("�������� Rocket");
    }
}
