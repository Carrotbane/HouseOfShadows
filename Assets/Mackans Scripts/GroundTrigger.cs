using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    private HumanCore _humanCore;

    private void Start()
    {
        _humanCore = GetComponentInParent<HumanCore>();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        _humanCore.isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _humanCore.isGrounded = false;
    }
}
