using UnityEngine;

public class ItemObject : MonoBehaviour
{
    private InventorySystem inventorySystem;
    private InventorySlotManager inventorySlotManager;
    public InventoryItemData referenceItem;

    private void Start()
    {
        inventorySystem = GameObject.Find("Inventory").GetComponent<InventorySystem>();
        inventorySlotManager = GameObject.Find("InventoryBar").GetComponent<InventorySlotManager>();
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name.Equals("Human"))
        {
            inventorySystem.Add(referenceItem);
            Destroy(gameObject);
        }
    }
}
