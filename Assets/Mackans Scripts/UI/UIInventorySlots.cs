using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class UIInventorySlots : MonoBehaviour
{
    [SerializeField]
    private Image icon;

    [SerializeField]
    private TextMeshProUGUI textLabel;

    [SerializeField]
    private GameObject stackObj;

    [SerializeField]
    private TextMeshProUGUI stackLabel;

    public void Set(InventoryItem item)
    {
        icon = gameObject.GetComponentInChildren<Image>();
        textLabel.text = item.data.displayName;
        stackLabel.text = item.stackSize.ToString();

        if (item.stackSize <= 1)
            stackObj.SetActive(false);
    }
}
