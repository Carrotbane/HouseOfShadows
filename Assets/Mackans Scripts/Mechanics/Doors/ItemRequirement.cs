using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRequirement : MonoBehaviour
{
    [SerializeField]
    private InventoryItemData _itemData;

    private InventorySystem _inventorySystem;

    private void Start()
    {
        _inventorySystem = GameObject.Find("Inventory").GetComponent<InventorySystem>();
    }

    public bool HasItem()
    {
        return _inventorySystem.Get(_itemData);
    }

    public void ConsumeItem()
    {
        _inventorySystem.Remove(_itemData);
    }
}
