using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    private HumanCore _humanCore;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _humanCore = GetComponentInParent<HumanCore>();
        _rigidbody2D = GetComponentInParent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (_rigidbody2D.velocity.y <= 0)
            _humanCore.isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _humanCore.isGrounded = false;
    }
}
