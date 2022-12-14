using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform followTransform;


    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y+2, this.transform.position.z);

    }
}
