using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;
    private float health;
    public Defense defense;

    private void Start()
    {
        defense = this.GetComponent<Defense>();
        health = maxHealth;
    }

    public void takeDamage(float x)
    {
        health -= x;

        if(health < 0)
            health = 0;
    }

    public void attack(float x) { 
        if(defense != null)
        {
            defense.onDefense();
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

}
