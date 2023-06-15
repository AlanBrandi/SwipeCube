using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAudioPlay : MonoBehaviour
{
    [SerializeField] private GameObject audioDeath;
    [SerializeField] private GameObject audioRandom;
    [SerializeField] private GameObject Music;
    [SerializeField] private GameObject audioBeginning;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioRandom.SetActive(false);
            audioRandom.GetComponent<RandomAudioPlayer>().enabled = false;
            Music.SetActive(false); 
            audioBeginning.SetActive(false); 
            audioDeath.SetActive(true);
        }
    }
}
