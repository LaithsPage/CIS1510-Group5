using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : Death
{
    public override void onDeath()
    {
        base.onDeath();
        /* 
            this.gameObject.SetActive(false);
        */

    }
}
