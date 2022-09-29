using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyXP : XPParent
{
    [Header("Enemy")]
    public int setLevel = 0;

    private void Start()
    {
        foreach (XPType x in Enum.GetValues(typeof(XPType)))
        {
            xpLevel[x] = setLevel;
            xp[x] = xpPerLevel[xpLevel[x]];
        }
    }

    //TODO drop xp
}
