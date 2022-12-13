using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallThroughPlatform : MonoBehaviour
{
    private Collider2D _collider2D;
    private bool _playerOnPlatform;
    private HumanMovement humanMovement;
    private Collider2D humanCollider2D;

    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();
        humanMovement = GameObject.Find("Human").GetComponent<HumanMovement>();
        humanCollider2D = humanMovement.GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (_playerOnPlatform && humanMovement.isCrouching)
        {
            //_collider2D.enabled = false;
            Physics2D.IgnoreCollision(_collider2D, humanCollider2D, true);
            StartCoroutine(EnableCollider());
        }
    }

    private IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreCollision(_collider2D, humanCollider2D, false);
    }

    private void SetPlayerOnPlatform(Collision2D other, bool value)
    {
        var player = other.gameObject.GetComponent<HumanCore>();
        if (player != null)
            _playerOnPlatform = value;
    }

    private void OnCollisionEnter2D(Collision2D otherCol)
    {
        SetPlayerOnPlatform(otherCol, true);
    }

    private void OnCollisionExit2D(Collision2D otherCol)
    {
        SetPlayerOnPlatform(otherCol, true);
    }
}
