using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    private List<Collider2D> InColliders = new ();
    
    void OnTriggerEnter2D(Collider2D col)
    {
        InColliders.Add(col);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        InColliders.Remove(col);
    }
    
    private void InteractAction()
    {
        if (InColliders != null)
        {
            foreach (var col in InColliders.Where(col => col != null && col.gameObject.CompareTag("Switch")))
            {
                col.SendMessage("Use", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
    
    public void InteractEvent(InputAction.CallbackContext context)
    {
        if (context.action.WasPerformedThisFrame())
            InteractAction();
    }
}
