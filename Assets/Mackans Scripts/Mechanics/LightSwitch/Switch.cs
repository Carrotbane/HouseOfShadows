using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField]
    private GameObject Target;
    
    [SerializeField]
    private Sprite switchOnSprite;
    
    [SerializeField]
    private Sprite switchOffSprite;

    private SpriteRenderer _renderer;
    private ObjectsManager _objManager;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _objManager = Target.GetComponent<ObjectsManager>();
    }

    public void Use()
    {
        Target.SendMessage("Toggle");
        
        _renderer.sprite = _objManager.state ? 
            switchOnSprite : switchOffSprite ;
    }
}
