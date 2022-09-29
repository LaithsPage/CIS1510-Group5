using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform map;
    private Transform spawn;

    private void Start()
    {
        spawn = map.Find("Spawn");
        transform.position = spawn.position + new Vector3(0, transform.position.y, 0);
    }
}
