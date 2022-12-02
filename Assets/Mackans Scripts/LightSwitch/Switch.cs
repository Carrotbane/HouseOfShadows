using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject Target;
    public string OnMessage;
    public string OffMessage;
    public bool IsLightOn;

    public void SwitchOn()
    {
        if (!IsLightOn)
        {
            SetState(true);
        }
    }

    public void SwitchOff()
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
            SwitchOff();
        }
        else
        {
            SwitchOn();
        }
    }

    void SetState(bool on)
    {
        IsLightOn = on;
        if(on)
        {
            if(Target!=null && !string.IsNullOrEmpty(OnMessage))
            {
                Target.SendMessage(OnMessage);
            }
        }
        else
        {
            if (Target!= null && !string.IsNullOrEmpty(OffMessage))
            {
                Target.SendMessage(OffMessage);
            }
        }
    }
    
}
