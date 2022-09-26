using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float damage;
    public float fireRate;
    public float range;

    private Inventory inventory;

    private Transform target;
    private bool startUpdate = false;

    private float waitTime;
    private void Awake()
    {
        inventory = GetComponent<Inventory>();
    }
    private void Start()
    {
        damage = inventory.getWeaponDamage();
        fireRate = inventory.getWeaponFireRate();
        range = inventory.getWeaponRange();
        waitTime = 1 / fireRate;
    }
    private void Update()
    {
        if (startUpdate)
        {
            damage = inventory.getWeaponDamage();
            fireRate = inventory.getWeaponFireRate();
            range = inventory.getWeaponRange();
            float nextFireTime = Time.time + waitTime;
            if(nextFireTime <= Time.time)
            {
                doAttack();
            }
        }
    }

    public void startAttack(Transform Enemy)
    {
        startUpdate = true;
        target = Enemy;
    }

    public void endAttack()
    {
        target = null;
        startUpdate = false;
    }

    private void doAttack()
    {
        target.GetComponent<Health>().attack(damage);
    }
}
