using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon", fileName = "Weapon")]
public class Weapon : ScriptableObject
{
    enum WeaponType
    {
        Melee,
        Ranged,
        Magic
    }
    [SerializeField] WeaponType weaponType;
    public float fireRate;
    public float range;
}
