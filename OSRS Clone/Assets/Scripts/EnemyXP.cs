using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyXP : XPParent
{
    [Header("Enemy")]
    public int setLevel = 0;

    private void Start()
    {
        foreach (KeyValuePair<XPType, int> entry in xpLevel)
        {
            xpLevel[entry.Key] = setLevel;
            xp[entry.Key] = xpPerLevel[xpLevel[entry.Key]];
        }
    }

    //TODO drop xp
}
