using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowAttachment : MonoBehaviour
{
    private ShadowCore _shadowCore;
    [SerializeField] private _enumOption _playerOption = _enumOption.Attach;

    private enum _enumOption
    {
        Attach, Deattach
    }
    
    void Start()
    {
        _shadowCore = GameObject.Find("Shadow").GetComponent<ShadowCore>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Human"))
        {
            switch (_playerOption)
            {
                case _enumOption.Attach:
                    _shadowCore.AttachShadow();
                    break;
            
                case _enumOption.Deattach:
                    _shadowCore.DeattachShadow();
                    break;
            }
        }
    }
}
