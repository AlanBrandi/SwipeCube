using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera newCamera;
    [SerializeField] private CinemachineVirtualCamera OldCamera;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OldCamera.gameObject.SetActive(false);
            newCamera.gameObject.SetActive(true);
        }
    }
}
