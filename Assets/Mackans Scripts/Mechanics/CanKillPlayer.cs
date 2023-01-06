using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CanKillPlayer : MonoBehaviour
{
    [SerializeField] private Transform resetPosition;
    [SerializeField] private _enumOption _playerOption = _enumOption.Human;
    
    private enum _enumOption
    {
        Human, Shadow
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (_playerOption.Equals(_enumOption.Human))
        {
            var player = GameObject.Find("Human").transform;
            player.position = resetPosition.position;
        }
        else
        {
            var shadow = GameObject.Find("Shadow").transform;
            shadow.position = resetPosition.position;
        }
    }
}
