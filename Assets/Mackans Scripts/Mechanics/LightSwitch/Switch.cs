using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject Target;

    public void Use()
    {
        Target.SendMessage("Toggle");
    }
}
