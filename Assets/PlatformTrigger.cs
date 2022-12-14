using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{

    public GameObject platform;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
    }

}
