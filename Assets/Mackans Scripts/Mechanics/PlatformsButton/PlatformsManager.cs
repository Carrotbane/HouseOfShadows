using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsManager : MonoBehaviour
{
    private List<Transform> platformList = new ();
    private bool state = true;
    
    private void Start()
    {
        foreach (Transform child in transform)
            platformList.Add(child);
    }

    // Update is called once per frame
    public void Toggle()
    {
        state = !state;
        foreach (Transform platform in platformList)
            platform.gameObject.SetActive(state);
    }
}
