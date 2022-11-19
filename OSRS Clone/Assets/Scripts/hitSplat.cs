using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class hitSplat : MonoBehaviour
{
    // Create a Damage Popup
    public static void Create(Camera cam, Transform parent, Transform recipient, int damageAmount)
    {
        Transform pfHitSplat = Resources.Load<Transform>("hitSplat");
        Transform hitSplatTransform = Instantiate(pfHitSplat, cam.WorldToScreenPoint(recipient.transform.position), Quaternion.identity, parent); //THIS IS WHERE THE ERROR IS

        hitSplat _hitsplat = hitSplatTransform.GetComponent<hitSplat>();
        _hitsplat.Setup(damageAmount, cam, recipient);
    }

    private static int sortingOrder;

    private TextMeshProUGUI textMesh;
    private float deleteTime = 1f;
    private float disappearTime;
    private Vector3 moveVector;

    private Camera cam;
    private Transform recipient;

    private void Awake()
    {
        textMesh = this.transform.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Setup(int damageAmount, Camera cam, Transform recipient)
    {
        this.cam = cam;
        this.recipient = recipient;

        textMesh.SetText(damageAmount.ToString());

        disappearTime = deleteTime;

        sortingOrder++;
        //textMesh.sortingOrder = sortingOrder;

        moveVector = new Vector3(.7f, 1) * 60f;
    }

    void Update()
    {
        this.transform.position = cam.WorldToScreenPoint(recipient.transform.position);
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

        disappearTime -= Time.deltaTime;
        if (disappearTime < 0)
        {
            Destroy(gameObject);
        }
    }
}
