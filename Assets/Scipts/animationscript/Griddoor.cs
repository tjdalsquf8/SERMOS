using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDoor : MonoBehaviour
{
    private Animator _animator;
    [SerializeField]
    private AudioClip _openSound1;
    [SerializeField]
    private AudioClip _openSound2;
    private AudioSource audio;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();

    }

    private void Start()
    {
        audio.clip = _openSound1;
        audio.clip = _openSound2;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AniSetBool(bool isOpen)
    {
        audio.Play();
        _animator.SetBool("isOpen", isOpen);
    }

    public bool AniGetBool()
    {
        return _animator.GetBool("isOpen");
    }
}