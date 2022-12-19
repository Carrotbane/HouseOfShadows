using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SceneEntrance : MonoBehaviour
{
    public int lastExitValue;
    
    void Start()
    {
        if (PlayerPrefs.GetInt("LastExitName") == lastExitValue)
        {
            Vector3 newPosition = transform.position;
            Transform playersTransform = GameObject.Find("Players").transform;
            
            playersTransform.GetChild(0).position = newPosition;
            playersTransform.GetChild(1).position = newPosition;
        }
    }
}
