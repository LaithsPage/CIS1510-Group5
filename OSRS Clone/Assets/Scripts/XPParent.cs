using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPParent : MonoBehaviour
{
    public enum XPType
    {
        Attack,
        Magic,
        Construction
    }
    public Dictionary<XPType, int> xp = new Dictionary<XPType, int>();
    public Dictionary<XPType, int> xpLevel = new Dictionary<XPType, int>();

    public float exponent = 2.5f;

    public float[] xpPerLevel;

    private void Start()
    {
        foreach (XPType x in Enum.GetValues(typeof(XPType)))
        {
            xp.Add(x, 0);
            xpLevel.Add(x, 0);
        }
        for(int i = 0; i < 100; i++)
        {
            xpPerLevel[i] = (int)Mathf.Pow(i, exponent); //LEVEL 100 = 1000xp with x^1.5, 10000 with x^2
        }
    }

    public void addXP(XPType type, int add)
    {
        xp[type] += add;

        if (xp[type] >= xpPerLevel[xpLevel[type]])
        {
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


