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

    public delegate void DoDefense();
    public static event DoDefense doDefense;

    Attack attack;
    private Transform attacker;

    private Patrol patrol;

    private void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        attack = gameObject.GetComponent<Attack>();
        patrol = gameObject.GetComponent<Patrol>();

        doDefense = () => Debug.Log("doDefense has not been Assigned");
    }

    private void Update()
    {
        if (startUpdate)
        {
            doDefense();
        }
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
                attack?.endAttack();
                patrol?.GotoNextPoint();
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
        switch (defenseStyle)
        {
            case DefensiveStyle.Passive:
                agent.speed *= .5f;
                break;
            case DefensiveStyle.Aggressive:
                doDefense = () =>
                {
                    if (this.GetComponent<Attack>() == null)
                        return;
                    attack.startAttack(attacker);
                    agent.SetDestination(attacker.position);
                };
                break;
            case DefensiveStyle.Scared:
                break;
            default:
                break;
        }
    }

    public void SetAttacker(Transform attacker)
    {
        this.attacker = attacker;
    }
}
