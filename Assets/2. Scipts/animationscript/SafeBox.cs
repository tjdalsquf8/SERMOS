using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeBox : MonoBehaviour
{
    Animator _animator;
    /*[SerializeField]
    private AudioClip _openSound;
    private AudioSource _audio;
    */
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        //_audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        //_audio.clip = _openSound;
    }

    public void AniSetBool(bool isOpen)
    {
        _animator.SetBool("isOpen", isOpen);
        //_audio.Play();
    }
    public bool AniGetBool() {
        return _animator.GetBool("isOpen");
            }
}

