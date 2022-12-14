using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit : MonoBehaviour
{
    public string sceneToLoad;
    public string exitName;
    public bool requireItem;
    public bool consumeItem;

    private ItemRequirement _itemRequirement;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Human"))
        {
            if (requireItem && !GetComponent<ItemRequirement>().HasItem())
                return;
        
            PlayerPrefs.SetString("LastExitName", exitName);
            SceneManager.LoadScene(sceneToLoad);
        
            if (consumeItem)
                GetComponent<ItemRequirement>().ConsumeItem();
        }
    }
}
