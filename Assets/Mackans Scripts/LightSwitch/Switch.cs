using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject Target;
    public string OnMessage;
    public string OffMessage;
    public bool IsSwitchOn;

    public void SwitchOn()
    {
        if (!IsSwitchOn)
        {
            SetState(true);
        }
    }

    public void SwitchOff()
    {
        if(IsSwitchOn)
        {
            SetState(false);
        }
    }
    public void Toggle()
    {
        if(IsSwitchOn)
        {
            SwitchOff();
        }
        else
        {
            SwitchOn();
        }
    }

    void SetState(bool state)
    {
        IsSwitchOn = state;
        if (state)
        {
            if(Target != null && !string.IsNullOrEmpty(OnMessage))
            {
                Target.SendMessage(OnMessage);
            }
        }
        else
        {
            if (Target != null && !string.IsNullOrEmpty(OffMessage))
            {
                Target.SendMessage(OffMessage);
            }
        }
    }
    
}
