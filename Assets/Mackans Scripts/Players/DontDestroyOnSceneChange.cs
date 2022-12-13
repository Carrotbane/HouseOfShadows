using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnSceneChange : MonoBehaviour
{
    public static DontDestroyOnSceneChange instance;
    
    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
