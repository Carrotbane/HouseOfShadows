using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private string itemName;
    public InventoryItemData data { get; private set; }
    public int stackSize { get; private set; }
    
    public InventoryItem(InventoryItemData source)
    {
        data = source;
        AddToStack();
    }

    public void Create(InventoryItemData source)
    {
        data = source;
        itemName = data.displayName;
        AddToStack();
    }

    public void AddToStack()
    {
        stackSize++;
    }

    public void RemoveFromStack()
    {
        stackSize--;
    }
}
