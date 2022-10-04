using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Attack : MonoBehaviour
{
    float damage;
    float fireRate;
    float range;

    private Inventory inventory;
    private PlayerXP xp;
    private Transform target;
    private bool startUpdate = false;

    private float waitTime;
    private float nextFireTime = 0f;
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
        xp = GetComponent<PlayerXP>();
    }
    private void Update()
    {
        if (startUpdate && target.GetComponent<Health>().getHealth() > 0)
        {

            damage = inventory.getWeaponDamage();
            fireRate = inventory.getWeaponFireRate();
            range = inventory.getWeaponRange();
            if (nextFireTime <= Time.time)
            {
                doAttack();
                nextFireTime = Time.time + waitTime;
            }
        }
    }

    public void startAttack(Transform Enemy)
    {
        nextFireTime = Time.time + waitTime;
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
        
        if (xp != null)
        {
            Defense d = target.GetComponent<Defense>();
            if (d != null)
            {
                d.SetAttacker(this.transform);
            }

            int level = (int)xp.getLevel(inventory.weaponTypeToXP());
            float accuracy = xp.accuracyPerLevel[level];

            float random = Random.Range(0f, 1f);
            if(random <= accuracy)
            {
                target.GetComponent<Health>().attack(damage);
                Debug.Log("Hit! "+ target.GetComponent<Health>().getHealth());
            }
            else
            {
                target.GetComponent<Health>().attack(0);
                Debug.Log("Miss! " + target.GetComponent<Health>().getHealth());

            }
            
        }
        
    }
}
