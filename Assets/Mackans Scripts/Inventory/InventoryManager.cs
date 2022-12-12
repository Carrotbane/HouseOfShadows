using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private InventorySystem inventorySystem;

    public GameObject itemSlotPrefab;

    private void Awake()
    {
        inventorySystem = gameObject.GetComponent<InventorySystem>();
    }

    public void ItemPickup()
    {
        foreach (Transform t in transform)
            Destroy(t.gameObject);
        
        DrawInventory();
    }

    public void DrawInventory()
    {
        foreach (InventoryItem item in inventorySystem.inventory)
            AddInventorySlot(item);
    }

    private void AddInventorySlot(InventoryItem item)
    {
        
    }
}
