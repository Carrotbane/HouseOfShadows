using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow_Two : MonoBehaviour
{
 
     public Transform Human, Shadow, CameraFocus;
     public float minSizeY = 5f;
 
     void SetCameraPos() {
         Vector3 middle = (Human.position + Shadow.position) * 0.5f;
 
         GetComponent<Camera>().transform.position = new Vector3(
             middle.x,
             middle.y,
             GetComponent<Camera>().transform.position.z
         );
     }
 
     void SetCameraSize() {
         //horizontal size is based on actual screen ratio
         float minSizeX = minSizeY * Screen.width / Screen.height;
 
         //multiplying by 0.5, because the ortographicSize is actually half the height
         float width = Mathf.Abs(Human.position.x - Shadow.position.x) * 0.5f;
         float height = Mathf.Abs(Human.position.y - Shadow.position.y) * 0.5f;
 
         //computing the size
         float camSizeX = Mathf.Max(width, minSizeX);
         GetComponent<Camera>().orthographicSize = Mathf.Max(height,
             camSizeX * Screen.height / Screen.width, minSizeY);
     }
 
     void Update() {
         SetCameraPos();
         SetCameraSize();
     }
 }