using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotManager : MonoBehaviour
{
    private InventorySystem inventorySystem;

    public GameObject itemSlotPrefab;

    private void Awake()
    {
        inventorySystem = GameObject.Find("Inventory").GetComponent<InventorySystem>();
    }

    public void DrawInventory()
    {
        foreach (Transform t in transform)
            Destroy(t.gameObject);
        
        foreach (InventoryItem item in inventorySystem.inventory)
            AddInventorySlot(item);
    }

    private void AddInventorySlot(InventoryItem item)
    {
        GameObject obj = Instantiate(itemSlotPrefab, transform, false);

        //Debug.Log(obj.GetComponent<UIInventorySlots>());
        
        UIInventorySlots slot = obj.GetComponent<UIInventorySlots>();
        slot.Set(item);
    }
}
