using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BreakingWood : MonoBehaviour
{
    private const int partSize = 2;
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private AudioClip breaksound;
    
    private AudioSource _audio;

    private Rigidbody _rb;

    private bool isBreaked = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _audio = GetComponent<AudioSource>();
        _audio.clip = breaksound;
    }
    // Update is called once per frame
    void Update()
    {
        if (isBreaked==true)
        {
            _rb.isKinematic = false;
            _rb.AddForce( 20 * Vector3.right, ForceMode.Impulse);
            _audio.Play();
            door.transform.tag = "door";
            isBreaked = false;
            this.enabled = false;
        }
    }

    public void SetisBreaked(bool value)
    {
        isBreaked = value;
        return;
    }
}
