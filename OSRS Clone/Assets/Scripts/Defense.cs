using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : MonoBehaviour
{

    //TODO: On attacked, do defensive style until unfocused; add method like amIfocused? amIbeingAttacked?
    public enum DefensiveStyle
    {
        Passive,
        Aggressive,
        Scared
    }

    public DefensiveStyle defenseStyle;

}
