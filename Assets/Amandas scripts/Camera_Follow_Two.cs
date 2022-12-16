using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Camera_Follow_Two : MonoBehaviour
{
     private Camera cameraObj;
     private Vector3 middle, dCenterDist;
     private float xPos, yPos;
     
     public Transform Human, Shadow, CameraFocus;
     public bool SceneHasCenter = true, lockXaxis, lockYaxis;
     [SerializeField, Range(1f, 4f)] private float trackingSpeed = 0.5f;
     [SerializeField, Range(0f, 20f)] private float overShoot = 5f, minSizeY = 5f;
     [SerializeField, Range(0f, 1f)] private float factor = 0.5f;
     
     private void Start()
     {
         cameraObj = GetComponent<Camera>();
     }

     void SetCameraPos() {
         if (SceneHasCenter)
         {
             Vector3 playerCenter = (Human.position + Shadow.position) * 0.5f;
             dCenterDist = playerCenter - CameraFocus.position;
             middle = playerCenter - dCenterDist * factor;
         }
         else
             middle = (Human.position + Shadow.position) * 0.5f;

         Vector3 cameraPos = cameraObj.transform.position;
         xPos = Mathf.Lerp(cameraPos.x, middle.x, Time.deltaTime * trackingSpeed);
         yPos = Mathf.Lerp(cameraPos.y, middle.y, Time.deltaTime * trackingSpeed);

         cameraObj.transform.position = new Vector3(
             lockXaxis ? CameraFocus.position.x : xPos,
             lockYaxis ? CameraFocus.position.y : yPos,
             cameraPos.z
         );
     }
 
     void SetCameraSize() {
         //horizontal size is based on actual screen ratio
         float minSizeX = minSizeY * Screen.width / Screen.height;
 
         //multiplying by 0.5, because the orthographicSize is actually half the height
         float width = 0.5f * (Mathf.Abs(Human.position.x - Shadow.position.x) + overShoot);
         float height = 0.5f * (Mathf.Abs(Human.position.y - Shadow.position.y) + overShoot);
 
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