using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ConcreteDoor : MonoBehaviour
{
    public AudioClip audioClip; // AudioClip을 저장할 변수
    private AudioSource audioSource; // AudioSource 컴포넌트를 참조할 변수
    private Animator _animator; // Animator 컴포넌트를 참조할 변수

    private void Awake()
    {
        // Animator 컴포넌트를 가져옵니다.
        _animator = GetComponent<Animator>();
        // AudioSource 컴포넌트를 가져옵니다.
        audioSource = GetComponent<AudioSource>();
        // AudioSource에 AudioClip을 설정합니다.
        audioSource.clip = audioClip;
    }

    public void AniGetBool(bool isOpen)
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
        // Animator의 isOpen 값을 설정합니다.
        _animator.SetBool("isOpen", isOpen);
    }

    public bool AniGetBool()
    {
        // Animator의 isOpen 값을 반환합니다.
        return _animator.GetBool("isOpen");
    }
}