using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow_Two : MonoBehaviour
{
     private Camera cameraObj;
     private Vector3 middle;
     public Transform Human, Shadow, CameraFocus;
     public float minSizeY = 5f, factor = 0.5f;
     public bool SceneHasCenter = true, lockXaxis, lockYaxis;
     
     private void Start()
     {
         cameraObj = GetComponent<Camera>();
     }

     void SetCameraPos() {
         if (SceneHasCenter)
         {
             Vector3 playerCenter = (Human.position + Shadow.position) * 0.5f;
             Vector3 centerDeltaDistance = playerCenter - CameraFocus.position;
             middle = playerCenter - centerDeltaDistance * factor;
             //middle = playerCenter + CameraFocus.position * SceneCenterSkew;
         }
         else
             middle = (Human.position + Shadow.position) * 0.5f;

         cameraObj.transform.position = new Vector3(
             lockXaxis ? CameraFocus.position.x : middle.x,
             lockYaxis ? CameraFocus.position.y : middle.y,
             cameraObj.transform.position.z
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
         cameraObj.orthographicSize = Mathf.Max(height,
             camSizeX * Screen.height / Screen.width, minSizeY);
     }
 
     void Update() {
         SetCameraPos();
         SetCameraSize();
     }
 }