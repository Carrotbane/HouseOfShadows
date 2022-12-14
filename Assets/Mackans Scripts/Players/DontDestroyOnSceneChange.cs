using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnSceneChange : MonoBehaviour
{
    void Start()
    {
        for (int i = 0; i < FindObjectsOfType<DontDestroyOnSceneChange>().Length; i++)
        {
            if (FindObjectsOfType<DontDestroyOnSceneChange>()[i] != this)
            {
                if (FindObjectsOfType<DontDestroyOnSceneChange>()[i].name == gameObject.name)
                {
                    Destroy(gameObject);
                }
            }

        }

        DontDestroyOnLoad(gameObject);
    }
}
