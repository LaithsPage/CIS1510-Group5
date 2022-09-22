using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPParent : MonoBehaviour
{
    public enum XPType
    {
        Attack,
        Ranged,
        Magic
    }

    public Dictionary<XPType, int> xp = new Dictionary<XPType, int>();
    public Dictionary<XPType, int> xpLevel = new Dictionary<XPType, int>();

    public List<int> xpPerLevel;
    public int maxLevel = 100;
    public float exponent = 2.5f;

    private void Start()
    {
        foreach (XPType x in Enum.GetValues(typeof(XPType)))
        {
            xp.Add(x, 1);
            xpLevel.Add(x, 1);
        }
        for(int i = 0; i <= maxLevel; i++)
        {
            xpPerLevel.Add((int)Mathf.Pow(i, exponent)); //LEVEL 100 = 1000xp with x^1.5, 10000 with x^2
        }
    }

    public void addXP(XPType type, int add)
    {
        xp[type] += add;

        if (xp[type] >= xpPerLevel[xpLevel[type] + 1] && xpLevel[type] < maxLevel)
        {
            xpLevel[type] += 1;
        }
    }

    public float getXP(XPType type)
    {
        return xp[type];
    }

    public float getLevel(XPType type)
    {
        return xpLevel[type];
    }

    public float xpToNextLevel(XPType type)
    {
        if (xpLevel[type] < 100)
        {
            return xpPerLevel[xpLevel[type] + 1] - xpLevel[type];
        }
        else
        {
            return 0f;
        }
    }

}


