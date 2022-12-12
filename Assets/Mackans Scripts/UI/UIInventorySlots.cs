using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class UIInventorySlots : MonoBehaviour
{
    private Sprite icon;

    private TextMeshProUGUI textLabel;

    private GameObject stackObj;

    private TextMeshProUGUI stackLabel;

    public void Set(InventoryItem item)
    {
        icon = item.data.icon;
        textLabel.text = item.data.displayName;
        stackLabel.text = item.stackSize.ToString();

        if (item.stackSize <= 1)
            stackObj.SetActive(false);
    }
}
