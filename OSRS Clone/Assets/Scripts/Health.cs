using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    
    public float maxHealth = 100;
    private float health;
    private HealthBar healthBar;
    [HideInInspector] public Defense defense;

    private void Start()
    {
        healthBar = this.transform.GetComponentInChildren<HealthBar>();
        defense = this.GetComponent<Defense>();
        health = maxHealth;

        healthBar.SetMaxHealth(health);
    }

    public void takeDamage(float x)
    {
        health -= x;
        healthBar.SetHealth(health);

        if(health < 0)
            health = 0;

        
    }

    public void attack(float x) { 
        if(defense != null)
        {
            if (defense.getUpdate() == false)
            {
                defense.startDefense();
            }
        }
        takeDamage(x); 
    }

    public void heal(float x)
    {
        health += x;

        if (health > maxHealth)
            health = maxHealth;
    }

    public float getHealth()
    {
        return health;
    }

    public float getMaxHealth()
    {
        return maxHealth;
    }

}
