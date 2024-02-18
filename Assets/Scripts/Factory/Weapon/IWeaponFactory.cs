using System;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponFactory
{
    IWeapon CreateWeapon(WeaponType weaponType);
}

