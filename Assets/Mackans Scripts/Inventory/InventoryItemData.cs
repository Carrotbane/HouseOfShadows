using UnityEngine;

[CreateAssetMenu(menuName = "Inventory Item Data")]
public class InventoryItemData : ScriptableObject
{
    public string id, displayName;
    public Sprite icon;
    public GameObject prefab;
}
