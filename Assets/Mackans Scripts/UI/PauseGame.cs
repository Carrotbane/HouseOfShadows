using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPaused;
    
    public void TogglePause()
    {
        if (!isPaused)
            Pause();
        else
            Resume();
        
        isPaused = !isPaused;
    }

    private void Pause()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Resume()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
