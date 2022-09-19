using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerXP : XPParent
{
    public enum XPType
    {
        Attack,
        Magic,
        Construction
    }
    Dictionary<XPType, float> xp = new Dictionary<XPType, float>();

    private void Start()
    {
        foreach(XPType x in Enum.GetValues(typeof(XPType)))
        {
            xp.Add(x, 0);
        }
    }

    public void addXP(XPType type, float add)
    {
        xp[type] += add;
    }

    public float getXP(XPType type)
    {
        return xp[type];
    }

    public float getLevel(XPType type)
    {



        return 0f;
    }

}
