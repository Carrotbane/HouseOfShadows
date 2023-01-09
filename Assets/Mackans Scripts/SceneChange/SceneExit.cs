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
    [SerializeField] private float transitionTime = 1f;
    [SerializeField] private LoadNextLevel _loadNextLevel;
    
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

        _loadNextLevel.ChangeLevel(transitionTime, exitName, destinationScene);
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
