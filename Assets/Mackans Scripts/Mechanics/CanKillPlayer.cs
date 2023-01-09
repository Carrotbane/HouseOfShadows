using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class CanKillPlayer : MonoBehaviour
{
    public UnityEvent onTriggerEnter;
    public AudioPlay audioPlay;
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
            onTriggerEnter.Invoke();
            audioPlay.PlayAudio();
        }
        else
        {
            var shadow = GameObject.Find("Shadow").transform;
            shadow.position = resetPosition.position;
            onTriggerEnter.Invoke();
            audioPlay.PlayAudio();
        }
    }
}
