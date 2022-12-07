using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class HumanCore : MonoBehaviour
{
    [HideInInspector] public bool isGrounded;
    
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
        foreach (var col in InColliders.Where(col => col.gameObject.CompareTag("Switch")))
        {
            col.SendMessage("Use", SendMessageOptions.DontRequireReceiver);
        }
    }
    
    public void InteractEvent(InputAction.CallbackContext context)
    {
        if (context.action.WasPerformedThisFrame())
            InteractAction();
    }
}
