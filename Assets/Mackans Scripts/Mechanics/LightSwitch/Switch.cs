using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Switch : MonoBehaviour
{
    [SerializeField]
    private GameObject Target;
    
    [SerializeField] 
    private bool holdDown;
    
    [SerializeField]
    private Sprite switchOnSprite;
    
    [SerializeField]
    private Sprite switchOffSprite;

    private SpriteRenderer _renderer;
    private ObjectsManager _objManager;

    //public AudioPlay audioPlay;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _objManager = Target.GetComponent<ObjectsManager>();    
    }

    private void StateChange()
    {
        Target.SendMessage("Toggle");
        //audioPlay.PlayAudio();
        
        _renderer.sprite = _objManager.state ? 
            switchOnSprite : switchOffSprite ;
    }

    public void Use()
    {
        StateChange();
    }
}
