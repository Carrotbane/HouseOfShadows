using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    [SerializeField] private GameObject parentEntity;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        parentEntity.GetComponent<HumanCore>().isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        parentEntity.GetComponent<HumanCore>().isGrounded = false;
    }
}
