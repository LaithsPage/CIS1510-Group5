using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float damage;
    public float fireRate;
    public float range;

    private float waitTime;
    private void Awake()
    {
        waitTime = 1 / fireRate;
    }

    public void startAttack(Transform Enemy)
    {

    }
}
