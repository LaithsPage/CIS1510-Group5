using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CamRotate : MonoBehaviour
{
    public float maxRotation = 5f;
    public float speed = 1f;

    private float og_rotation;
    private void Start()
    {
        og_rotation = transform.eulerAngles.y / 2;
    }
    private void Update()
    {
        transform.rotation = Quaternion.Euler(0f, (maxRotation * o(Time.time * speed) * -1f) + og_rotation, 0f);

    }

    float f(float x)
    {
        return -1f * Mathf.Cos(x);
    }

    float f_deriv(float x)
    {
        return Mathf.Sin(x);
    }

    float n(float x)
    {
        return 2 * (Mathf.Ceil(x) - 0.5f);
    }

    float r(float x)
    {
        return n(f_deriv(x) / Mathf.PI);
    }

    float g(float x)
    {
        return 2 * ((-1f * r(x)) * Mathf.Floor(x / 2));
    }

    float p(float x)
    {
        return (r(x) * x) - r(x) + g(x);
    }

    float o(float x)
    {
        return -1f * (-2f * (Mathf.Abs(p(x / 2))) + 1);
    }
}
