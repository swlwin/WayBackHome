//https://www.youtube.com/watch?v=Fqht4gyqFbo

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
   public Transform target;
   public Vector3 offset;
   [Range (1,10)]
   public float smoothFactor;
   public Vector3 minValue, maxValue;

   //-73.6, 97.1 x
   //2.8, -3.6 y
   private void FixedUpdate()
   {
        Follow();
   }

   void Follow()
   {
    Vector3 targetPosition = target.position + offset;
    Vector3 boundPosition = new Vector3(
        Mathf.Clamp(targetPosition.x, minValue.x, maxValue.x),
        Mathf.Clamp(targetPosition.y, minValue.y, maxValue.y),
        Mathf.Clamp(targetPosition.z, minValue.z, maxValue.z));
    Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor*Time.fixedDeltaTime);
    transform.position = smoothPosition;
   }

}
