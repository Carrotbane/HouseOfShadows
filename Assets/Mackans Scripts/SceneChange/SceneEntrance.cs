using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SceneEntrance : MonoBehaviour
{
    public string lastExitName;
    
    void Start()
    {
        
        if (PlayerPrefs.GetString("LastExitName") == lastExitName)
        {
            DontDestroyOnSceneChange.instance.transform.GetChild(0).position = transform.position;
            DontDestroyOnSceneChange.instance.transform.GetChild(1).position = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
