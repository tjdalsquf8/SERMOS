using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFootSoundController : MonoBehaviour
{
    [Header("Wood floor Audio Sounds")]
    [SerializeField]
    private  AudioClip[] woodFloorSound;

    [Header("Concreat floor Audio Sounds")]
    [SerializeField]
    private  AudioClip[] concreateFloorSound;

    [Header("Forest floor Audio Sounds")]
    [SerializeField]
    private AudioClip[] forestFloorSound;

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
        else if(other.CompareTag("forestFloor")) usingSounds = forestFloorSound; // w twings 03 4 8
    }
}
// enter 에서 발소리 리스트를 바꿈, up