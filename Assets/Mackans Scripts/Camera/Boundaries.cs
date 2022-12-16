using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    [HideInInspector] public float top, bottom, left, right;
    [SerializeField] private GameObject topObj, botObj, leftObj, rightObj;

    private void Start()
    {
        top = topObj.transform.position.y;
        bottom = botObj.transform.position.y;
        left = leftObj.transform.position.x;
        right = rightObj.transform.position.x;
    }
}
