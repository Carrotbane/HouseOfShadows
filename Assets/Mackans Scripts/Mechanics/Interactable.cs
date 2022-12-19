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
                SendMessage("Use", SendMessageOptions.DontRequireReceiver);
        }
        else
        {
            if (context.performed)
                SendMessage("Use", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void InteractLeave()
    {
        SendMessage("Use", SendMessageOptions.DontRequireReceiver);
    }
}
