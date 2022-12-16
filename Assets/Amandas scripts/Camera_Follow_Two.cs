using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Camera_Follow_Two : MonoBehaviour
{
     [SerializeField] private Boundaries boundaries;
     private Camera cameraObj;
     private Vector3 middle, dCenterDist;
     private float xPos, yPos;
     
     public Transform Human, Shadow, CameraFocus;
     public bool SceneHasCenter = true, lockXaxis, lockYaxis;
     [SerializeField, Range(1f, 4f)] private float trackingSpeed = 3f;
     [SerializeField, Range(1f, 4f)] private float sizingSpeed = 2f;
     [SerializeField, Range(0f, 20f)] private float overShoot = 12f, minSizeY = 8.5f;
     [SerializeField, Range(0f, 0.5f)] private float factor = 0.12f;
     [SerializeField, Range(0f, 3f)] private float timeUntilMove;
     
     private void Start()
     {
         cameraObj = GetComponent<Camera>();
         boundaries = GameObject.Find("MapBoundaries").GetComponent<Boundaries>();
     }
 
     private void Update()
     {
         if (!timeUntilMove.Equals(0))
         {
             timeUntilMove -= Time.deltaTime;
             if (timeUntilMove < 0)
                 timeUntilMove = 0;
             return;
         }
         
         SetCameraSize();
         SetCameraPos();
     }
 
     private void SetCameraSize() {
         //horizontal size is based on actual screen ratio
         float minSizeX = minSizeY * Screen.width / Screen.height;
 
         //multiplying by 0.5, because the orthographicSize is actually half the height
         float width = 0.5f * (Mathf.Abs(Human.position.x - Shadow.position.x) + overShoot);
         float height = 0.5f * (Mathf.Abs(Human.position.y - Shadow.position.y) + overShoot);
 
         //computing the size
         float camSizeX = Mathf.Max(width, minSizeX);
         float targetSize = Mathf.Max(height,
             camSizeX * Screen.height / Screen.width, minSizeY);
         
         cameraObj.orthographicSize = Mathf.Lerp(
             cameraObj.orthographicSize, targetSize, Time.deltaTime * sizingSpeed);
     }

     private void SetCameraPos() {
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
         MaintainBoundaries();

         cameraObj.transform.position = new Vector3(
             lockXaxis ? CameraFocus.position.x : xPos,
             lockYaxis ? CameraFocus.position.y : yPos,
             cameraPos.z
         );
     }

     private void MaintainBoundaries()
     {
         float camRadY = cameraObj.orthographicSize;
         float camRadX = cameraObj.orthographicSize * cameraObj.aspect;
         
         if (yPos > boundaries.top - camRadY)
             yPos = boundaries.top - camRadY;
         if (yPos < boundaries.bottom + camRadY)
             yPos = boundaries.bottom + camRadY;
         if (xPos < boundaries.left + camRadX)
             xPos = boundaries.left + camRadX;
         if (xPos > boundaries.right - camRadX)
             xPos = boundaries.right - camRadX;
     }
 }