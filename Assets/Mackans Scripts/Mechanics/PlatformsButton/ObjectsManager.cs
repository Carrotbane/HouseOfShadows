using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsManager : MonoBehaviour
{
    private List<Transform> platformList = new ();
    public bool state = true;
    
    private void Start()
    {
        foreach (Transform child in transform)
            platformList.Add(child);
    }

    // Update is called once per frame
    public void Toggle()
    {
        state = !state;
        foreach (Transform child in platformList)
        {
            bool isActive = child.gameObject.activeSelf;
            child.gameObject.SetActive(!isActive);
        }
            
    }
}
