using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject Target;

    public void Use()
    {
        Toggle();
    }
    
    private void Toggle()
    {
        Target.SendMessage("Toggle");
    }
}
