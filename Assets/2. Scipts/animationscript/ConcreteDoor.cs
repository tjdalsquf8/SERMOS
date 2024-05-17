using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ConcreteDoor : MonoBehaviour
{
    public AudioClip audioClip; // AudioClip�� ������ ����
    private AudioSource audioSource; // AudioSource ������Ʈ�� ������ ����
    private Animator _animator; // Animator ������Ʈ�� ������ ����

    private void Awake()
    {
        // Animator ������Ʈ�� �����ɴϴ�.
        _animator = GetComponent<Animator>();
        // AudioSource ������Ʈ�� �����ɴϴ�.
        audioSource = GetComponent<AudioSource>();
        // AudioSource�� AudioClip�� �����մϴ�.
        audioSource.clip = audioClip;
    }

    public void AniGetBool(bool isOpen)
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
        // Animator�� isOpen ���� �����մϴ�.
        _animator.SetBool("isOpen", isOpen);
    }

    public bool AniGetBool()
    {
        // Animator�� isOpen ���� ��ȯ�մϴ�.
        return _animator.GetBool("isOpen");
    }
}