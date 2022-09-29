using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollFOV : MonoBehaviour
{
    public Vector2 FovBoundaries;
    public float scroll_sensitivity;

    private Camera cam;
    private void Awake()
    {
        cam = GetComponent<Camera>();
    }
    private void Update()
    {
        float scrollwheel = Input.mouseScrollDelta.y;

        if(scrollwheel == 1) //mwheelup
        {
            if (cam.fieldOfView > FovBoundaries.x)
                cam.fieldOfView -= scroll_sensitivity;
        }
        else if(scrollwheel == -1) //mwheeldown
        {
            if (cam.fieldOfView < FovBoundaries.y)
                cam.fieldOfView += scroll_sensitivity;
        }
            
    }
}
