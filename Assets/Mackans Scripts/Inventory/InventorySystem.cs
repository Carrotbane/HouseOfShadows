using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private InventorySlotManager _iSlotManager;
    private Dictionary<InventoryItemData, InventoryItem> itemDictionary;
    public List<InventoryItem> inventory { get; private set; }

    private void Awake()
    {
        inventory = new List<InventoryItem>();
        itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
        _iSlotManager = GameObject.Find("InventoryBar").GetComponent<InventorySlotManager>();
    }

    public InventoryItem Get(InventoryItemData referenceData)
    {
        if (itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }

    public void Add(InventoryItemData referenceData)
    {
        if (itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            InventoryItem newItem = gameObject.AddComponent<InventoryItem>();
            newItem.Create(referenceData);
            inventory.Add(newItem);
            itemDictionary.Add(referenceData, newItem);
        }
        _iSlotManager.DrawInventory();
    }

    public void Remove(InventoryItemData referenceData)
    {
        Debug.Log("Remove item inventory");
        if (itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack();

            if (value.stackSize == 0)
            {
                inventory.Remove(value);
                itemDictionary.Remove(referenceData);
            }
        }
        _iSlotManager.DrawInventory();
    }
}
