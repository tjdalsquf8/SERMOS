using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    Animator _animator;
    [SerializeField]
    private AudioClip _openSound;
    private AudioSource audio;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        audio.clip = _openSound;
    }
    // Update is called once per frame


    public void AniSetBool(bool isOpen)
    {
        audio.Play();
        _animator.SetBool("isOpen", isOpen);
    }
    public bool AniGetBool() {
        audio.Play();
        return _animator.GetBool("isOpen"); 
    }
}
