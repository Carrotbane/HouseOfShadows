using UnityEngine;
using UnityEngine.Events;

public class ItemObject : MonoBehaviour
{
    private InventorySystem inventorySystem;
    private InventorySlotManager inventorySlotManager;
    public InventoryItemData referenceItem;
    public UnityEvent onTriggerEnter;

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
            onTriggerEnter.Invoke();
            Destroy(gameObject);
           
        }
    }
}
