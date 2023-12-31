using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeFall : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Player"))
      {
         Scene currentScene = SceneManager.GetActiveScene();
         SceneManager.LoadScene(currentScene.name);
      }
   }
}
