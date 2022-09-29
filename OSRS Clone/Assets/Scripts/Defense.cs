using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Defense : MonoBehaviour //EnemyDefense
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

    private bool startUpdate = false;


    private void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        
    }

    public bool getUpdate()
    {
        return startUpdate;
    }

    public void onDefense()
    {

    }
    public void onDeDefense()
    {
        switch (defenseStyle)
        {
            case DefensiveStyle.Passive:
                agent.speed *= 2f;
                break;
            case DefensiveStyle.Aggressive:
                break;
            case DefensiveStyle.Scared:
                break;
            default:
                break;
        }
        startUpdate = false;
    }

    public void startDefense()
    {
        startUpdate = true;
        if (startUpdate)
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
    }
}
