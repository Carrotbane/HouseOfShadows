using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    public bool IsLightOn;

    Collider2D MyCollider;

    void Start()
    {
        MyCollider = GetComponent<Collider2D>();
    }

    private void LightOn()
    {
        if(!IsLightOn)
        {
            SetState(true);
        }
    }

    private void LightOff()
    {
        if(IsLightOn)
        {
            SetState(false);
        }
    }

    public void Toggle()
    {
        if(IsLightOn)
        {
            LightOff();
        }
        else
        {
            LightOn();
        }
    }

    void SetState(bool on)
    {
        IsLightOn = on;
        MyCollider.isTrigger = on;
    }
}
