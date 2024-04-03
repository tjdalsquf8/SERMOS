using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Radio : MonoBehaviour
{


    [Header("Mirror's box collider")]
    [SerializeField]
    private MeshCollider _mirror;

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
        _audioSource.Play();
        _mirror.enabled = false;
    }
}
