using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Interactable))]
public class SceneExit : MonoBehaviour
{
    [SerializeField] private int destinationScene;
    [SerializeField] private bool requireItem;
    [SerializeField] private bool consumeItem;
    [SerializeField] private bool isInteractable;
    
    private string exitName;
    private ItemRequirement _itemRequirement;

    private void Start()
    {
        exitName = SceneManager.GetActiveScene().name;
    }

    private void SceneChange()
    {
        if (requireItem && !GetComponent<ItemRequirement>().HasItem())
            return;
    
        if (consumeItem)
            GetComponent<ItemRequirement>().ConsumeItem();
    
        PlayerPrefs.SetString("LastExitName", exitName);
        SceneManager.LoadScene(destinationScene);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!isInteractable)
            SceneChange();
    }

    public void Use()
    {
        if (isInteractable)
            SceneChange();
    }
}
