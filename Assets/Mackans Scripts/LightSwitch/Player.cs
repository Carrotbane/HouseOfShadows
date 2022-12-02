using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    List<Collider2D> InColliders = new List<Collider2D>();

    void Uptdate()
    {
        //InteractAction();
    }

    //private void InteractAction()
    //{
    //    InColliders.ForEach(n => n.SendMessage("Use", SendMessageOptions.DontRequireReceiver));
    //}
    //public void InteractEvent(InputAction.CallbackContext context) { }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        InColliders.Add(col);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        InColliders.Remove(col);
    }

    
}
