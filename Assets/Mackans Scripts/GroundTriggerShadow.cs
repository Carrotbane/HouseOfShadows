using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTriggerShadow : MonoBehaviour
{
    private ShadowCore _shadowCore;

    private void Start()
    {
        _shadowCore = GetComponentInParent<ShadowCore>();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        _shadowCore.isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _shadowCore.isGrounded = false;
    }
}
