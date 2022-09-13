using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform Follow;

    Vector3 old;

    Vector3 move;

    void Start()
    {
        old = Follow.position;
    }

    // Update is called once per frame
    void Update()
    {
        move = Follow.position - old;

        transform.position += move;

        old = Follow.position;
    }
}
