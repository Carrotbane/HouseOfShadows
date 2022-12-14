using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SceneEntrance : MonoBehaviour
{
    public int lastExitName;
    
    void Start()
    {
        if (PlayerPrefs.GetInt("LastExitName") == lastExitName)
        {
            Vector3 newPosition = transform.position;
            Transform playersTransform = GameObject.Find("Players").transform;
            
            playersTransform.GetChild(0).position = newPosition;
            playersTransform.GetChild(1).position = newPosition;
        }
    }
}
