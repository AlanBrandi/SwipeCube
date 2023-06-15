using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRotation : MonoBehaviour
{
   [SerializeField] private int rotationValue;
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Player"))
      {
         other.transform.rotation = new Quaternion(0, rotationValue, 0, 0);
      }
   }
}
