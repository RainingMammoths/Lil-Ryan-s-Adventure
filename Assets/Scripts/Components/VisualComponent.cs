using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class VisualComponent : MonoBehaviour
{
    SpriteRenderer rend;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    public IEnumerator BlinkAlpha(int mode, float alpha)
    {
        if (mode == 0) // Blink between semi transparent and not
        {
            rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, alpha);
            yield return new WaitForSeconds(.25f);
            rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, 1f);
            yield return new WaitForSeconds(.25f);
            rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, alpha);
            yield return new WaitForSeconds(.25f);
            rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, 1f);
            yield return new WaitForSeconds(.25f);
            rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, alpha);
            yield return new WaitForSeconds(2f);
            rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, 1f);
        }
        

    }
}
