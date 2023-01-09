using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    [SerializeField] private Animator transition;
    
    public void ChangeLevel(float transitionTime, string exitName, int destinationScene)
    {
        StartCoroutine(LoadLevel(transitionTime, exitName, destinationScene));
    }
    
    IEnumerator LoadLevel(float transitionTime, string exitName, int destinationScene)
    {
        transition.SetTrigger("SceneChanged");

        yield return new WaitForSeconds(transitionTime);
        
        PlayerPrefs.SetString("LastExitName", exitName);
        SceneManager.LoadScene(destinationScene);
    }
}
