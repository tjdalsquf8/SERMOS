using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDoor : MonoBehaviour
{
    private Animator _animator;
    [SerializeField]
    private AudioClip[] _gridDoorSounds; // 0 dont open sound, 1 first door handle sound, 2 open sound
    private AudioSource _audio;

    [Header("for open this door, key")]
    [SerializeField]
    private ItemPickUp key;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();

    }

    private void Start()
    {
        _audio.clip = _gridDoorSounds[0];
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AniSetBool(bool isOpen)
    {
        /*_audio.Play();
        _animator.SetBool("isOpen", isOpen);*/
        if (!key.GetIsHolded() && !isOpen) // if not holded
        {
            PlayDoorLockedSound();
        }else if(key.GetIsHolded() && key.GetKeyKind() == ItemPickUp.ObjKind.under)
        {
                if (!_audio.isPlaying)
                {
                StartCoroutine(PlayGridDoorSounds());
                }
            _animator.SetBool("isOpen", isOpen);
        }
    }

    public bool AniGetBool()
    {
        return _animator.GetBool("isOpen");
    }
    public void PlayDoorLockedSound()
    {
        _audio.clip = _gridDoorSounds[0];
        _audio.Play();
    }
    private IEnumerator PlayGridDoorSounds()
    {
        for (int i = 1; i <= 2; i++)
        {
            _audio.clip = _gridDoorSounds[i];
            _audio.Play();
            yield return new WaitForSeconds(_audio.clip.length);
        }
    }
}