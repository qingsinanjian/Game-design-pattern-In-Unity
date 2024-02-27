using System;
using System.Collections.Generic;
using UnityEngine;

public interface IAttrFactory
{
    CharacterBaseAttr GetCharacterBaseAttr(System.Type t);
    WeaponBaseAttr GetWeaponBaseAttr(WeaponType weaponType);
}

