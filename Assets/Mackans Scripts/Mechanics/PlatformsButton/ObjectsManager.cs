using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsManager : MonoBehaviour
{
    public bool state = true;
    
    public void Toggle()
    {
        state = !state;
        foreach (Transform child in transform)
            child.gameObject.SetActive(!child.gameObject.activeSelf);
    }
}
