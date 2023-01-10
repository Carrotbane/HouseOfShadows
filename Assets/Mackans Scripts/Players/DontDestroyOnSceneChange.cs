using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnSceneChange : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    void Start()
    {
        for (int i = FindObjectsOfType<DontDestroyOnSceneChange>().Length - 1; i >= 0; i--)
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

    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().buildIndex.Equals(0))
        {
            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoad;
    }
}
