using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTriggerShadow : MonoBehaviour
{
    [SerializeField] private GameObject parentEntity;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        parentEntity.GetComponent<ShadowCore>().isGroundedShadow = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        parentEntity.GetComponent<ShadowCore>().isGroundedShadow = false;
    }
}
