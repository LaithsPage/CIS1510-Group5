using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon", fileName = "Weapon")]
public class Weapon : ScriptableObject
{
    public enum WeaponType
    {
        Melee,
        Ranged,
        Magic
    }
    [SerializeField] public WeaponType weaponType;
    public float damage;
    public float fireRate;
    public float range;
}
