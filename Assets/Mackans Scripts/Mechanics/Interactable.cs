using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    public bool HoldDown;
    public bool HumanCanInteract = true, ShadowCanInteract = true;

    public void Interact(InputAction.CallbackContext context)
    {
        if (HoldDown)
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
