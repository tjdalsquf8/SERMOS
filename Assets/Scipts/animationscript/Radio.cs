using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Radio : MonoBehaviour
{
   

    private bool _audioPlayed = false;
    private AudioSource _audioSource;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>(); 
    }
    private void Start()
    {
    }
    public void AudioPlay()
    {
        if (_audioPlayed) return;
        Debug.Log("Play");
        _audioSource.Play();
        _audioPlayed = true;
    }
}
