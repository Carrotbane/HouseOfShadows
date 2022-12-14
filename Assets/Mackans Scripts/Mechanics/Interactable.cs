using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    public bool _holdDown;

    public void Interact(InputAction.CallbackContext context)
    {
        if (_holdDown)
        {
            if (context.performed || context.canceled)
                SendMessage("Use");
        }
        else
        {
            if (context.performed)
                SendMessage("Use");
        }
    }

    public void InteractLeave()
    {
        SendMessage("Use");
    }
}
