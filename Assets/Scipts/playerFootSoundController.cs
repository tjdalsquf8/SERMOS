using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFootSoundController : MonoBehaviour
{
    [Header("Wood floor Audio Sounds")]
    [SerializeField]
    private  AudioClip[] woodFloorSound;

    [Header("Concreat floor Audio Sound")]
    [SerializeField]
    private  AudioClip[] concreateFloorSound;

    private AudioClip[] usingSounds;
    private  AudioSource _audio;
    private  Animator _ani;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _ani = GameObject.Find("Player").GetComponent<Animator>();
        usingSounds = woodFloorSound;
    }
   
    
    public  void PlayFootSound()
    {
            _audio.clip = usingSounds[Random.Range(0, 3)];
            _audio.Play();
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("woodFloor"))  usingSounds = woodFloorSound; 
        else if(other.CompareTag("concreatFloor")) usingSounds = concreateFloorSound; 
    }
}
// enter 에서 발소리 리스트를 바꿈, up