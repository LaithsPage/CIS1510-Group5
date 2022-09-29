using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Don't go through terrain. Solution might be to raycast downwards and change the minxrotation if the distance is less 

public class CamOrbit : MonoBehaviour
{
    public Transform Player;
    public float distance;
    public float StartingAngle;

    Camera cam;

    Vector3 prevMousePos;
    Vector3 viewportDelta;

    public float viewportToRotationRatio;

    private float TrackedXRotation;
    private float XRotation;
    public float MinXRotation;
    public float MaxXRotation;
    
    void Start()
    {
        cam = Camera.main;
        distance = distance * -1f;
        cam.transform.position = Player.position;
        cam.transform.Rotate(new Vector3(1, 0, 0), StartingAngle);
        TrackedXRotation = StartingAngle;
        cam.transform.Translate(new Vector3(0, 0, distance));
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            prevMousePos = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(1))
        {
            viewportDelta = prevMousePos - cam.ScreenToViewportPoint(Input.mousePosition);

            cam.transform.position = Player.position;

            XRotation = viewportDelta.y * viewportToRotationRatio;//pos is mouse down, neg is mouse up (cam up, cam down)
            if (XRotation > 0 && TrackedXRotation < MaxXRotation)
            {
                if (XRotation + TrackedXRotation > MaxXRotation)
                {
                    XRotation = MaxXRotation - TrackedXRotation;
                }
                cam.transform.Rotate(new Vector3(1, 0, 0), XRotation); //up and down
                TrackedXRotation += XRotation;
            }
            else if (XRotation < 0 && TrackedXRotation >= MinXRotation)
            {
                if (XRotation + TrackedXRotation < MinXRotation)
                {
                    XRotation = MinXRotation - TrackedXRotation;
                }
                cam.transform.Rotate(new Vector3(1, 0, 0), XRotation); //up and down
                TrackedXRotation += XRotation;
            }
            cam.transform.Rotate(new Vector3(0,-1,0), viewportDelta.x * viewportToRotationRatio, Space.World); //left and 
            cam.transform.Translate(new Vector3(0, 0, distance));

            prevMousePos = cam.ScreenToViewportPoint(Input.mousePosition);
        }
    }
}
