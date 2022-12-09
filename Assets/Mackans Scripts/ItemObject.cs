using UnityEngine;

public class ItemObject : MonoBehaviour
{
    private InventorySystem inventorySystem;
    public InventoryItemData referenceItem;

    private void Start()
    {
        inventorySystem = GameObject.Find("Inventory").GetComponent<InventorySystem>();
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
