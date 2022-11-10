using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class hitSplat : MonoBehaviour
{
    // Create a Damage Popup
    public static hitSplat Create(Vector3 position, int damageAmount)
    {
        Transform hitSplatTransform = Instantiate(GameAssets.i.pfHitSplat, position, Quaternion.identity); //THIS IS WHERE THE ERROR IS

        hitSplat _hitsplat = hitSplatTransform.GetComponent<hitSplat>();
        _hitsplat.Setup(damageAmount);

        return null;
    }

    private static int sortingOrder;

    private TextMeshPro textMesh;
    private float deleteTime = 1f;
    private float disappearTimer;
    private Vector3 moveVector;

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(int damageAmount)
    {
        textMesh.SetText(damageAmount.ToString());

        disappearTimer = deleteTime;

        sortingOrder++;
        textMesh.sortingOrder = sortingOrder;

        moveVector = new Vector3(.7f, 1) * 60f;
    }

    private void Update()
    {
        //transform.position += moveVector * Time.deltaTime;
        moveVector -= moveVector * 8f * Time.deltaTime;

        /*if (disappearTimer > DISAPPEAR_TIMER_MAX * .5f)
        {
            // First half of the popup lifetime
            float increaseScaleAmount = 1f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        }
        else
        {
            // Second half of the popup lifetime
            float decreaseScaleAmount = 1f;
            transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }*/

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            Destroy(GetComponent<GameObject>());
        }
    }
}
