using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Defense : MonoBehaviour
{
    private NavMeshAgent agent;
    //TODO: On attacked, do defensive style until unfocused; add method like amIfocused? amIbeingAttacked?
    public enum DefensiveStyle
    {
        Passive,
        Aggressive,
        Scared
    }

    public DefensiveStyle defenseStyle;


    private void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }
    public void onDefense()
    {
        switch (defenseStyle)
        {
            case DefensiveStyle.Passive:
                agent.speed *= .5f;

                break;
            case DefensiveStyle.Aggressive:
                break;
            case DefensiveStyle.Scared:
                break;
            default:
                break;
        }
    }

    public void onDeDefense()
    {

    }

    public void StartDefense()
    {
        switch (defenseStyle)
        {
            case DefensiveStyle.Passive:
                agent.speed *= .5f
                break;
            case DefensiveStyle.Aggressive:
                break;
            case DefensiveStyle.Scared:
                break;
            default:
                break;
        }
    }
}
