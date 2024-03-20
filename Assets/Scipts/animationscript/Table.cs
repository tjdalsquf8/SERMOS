using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    Animator _animator;
    [SerializeField]
    private AudioClip _openSound;
    private  AudioSource _audio;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audio.clip = _openSound;
    }
    // Update is called once per frame


    public void AniSetBool(bool isOpen)
    {
        
        StartCoroutine(PlayGridDoorSounds());
        _animator.SetBool("isOpen", isOpen);
        StopCoroutine(PlayGridDoorSounds());
    }
    public bool AniGetBool() {
        return _animator.GetBool("isOpen"); 

    }
    private IEnumerator PlayGridDoorSounds()
    {
        _audio.Play();
        yield return new WaitForSeconds(_audio.clip.length);
    }
}
