using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour //EnemyDeath
{
    void Update()
    {
        float health = this.GetComponent<Health>().getHealth();

        if (health <= 0f)
        {
            onDeath();
        }
    }

    public virtual void onDeath()
    {
        this.gameObject.SetActive(false);
    }
}
