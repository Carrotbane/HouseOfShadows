using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    private InventorySystem inventorySystem;
    public InventoryItemData referenceItem;

    private void Start()
    {
        inventorySystem = GameObject.Find("Inventory").GetComponent<InventorySystem>();
    }

    public void OnHandlePickupItem()
    {
        inventorySystem.Add(referenceItem);
        Destroy(gameObject);
    }
}
