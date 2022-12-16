using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    private List<Collider2D> InColliders = new ();
    private bool isPressed;
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("GroundCheck"))
            return;
        
        InColliders.Add(col);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("GroundCheck"))
            return;
        
        if (isPressed)
        {
            isPressed = false;
            if (col.TryGetComponent(out Interactable script))
            {
                if (script._holdDown)
                {
                    script.InteractLeave();
                }
            }
        }
        
        InColliders.Remove(col);
    }
    
    public void InteractEvent(InputAction.CallbackContext context)
    {
        if (!isPressed && context.canceled)
            return;

        if (context.canceled)
            isPressed = false;

        if (InColliders != null)
        {
            foreach (var col in InColliders.Where(col => col != null))
            {
                if (col.TryGetComponent(out Interactable script))
                {
                    script.Interact(context);
                    
                    if (context.performed)
                        isPressed = true;
                }
            }
        }
    }
}
