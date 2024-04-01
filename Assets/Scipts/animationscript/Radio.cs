using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Radio : MonoBehaviour
{
    [Header("Radio Audio Clip")]
    [SerializeField]
    private AudioClip clip;

    private bool _audioPlayed = false;
    private AudioSource _audioSource;
    private void Awake()
    {
        
    }
    private void Start()
    {
    }
    public void AudioPlay()
    {
        Debug.Log("Audio Play!");
    }
}
