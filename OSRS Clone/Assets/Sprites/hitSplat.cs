using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class hitSplat : MonoBehaviour
{
    private TextMeshPro tmp;

    private void Start()
    {
        tmp = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(int damage)
    {
        tmp.SetText(damage.ToString());
    }
}
