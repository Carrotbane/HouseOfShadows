using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    public bool IsLightOn = true;
    private PolygonCollider2D lightCollider;
    private SpriteRenderer lightRenderer;

    void Start()
    {
        lightCollider = GetComponent<PolygonCollider2D>();
        lightRenderer = GetComponent<SpriteRenderer>();
    }

    public void Toggle()
    {
        IsLightOn = !IsLightOn;
        SetState(IsLightOn);
    }

    void SetState(bool state)
    {
        lightCollider.isTrigger = !state;
        lightRenderer.enabled = state;
    }
}
