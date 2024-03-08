using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFootSoundController : MonoBehaviour
{
    [Header("Wood floor Audio Sounds")]
    [SerializeField]
    private AudioClip[] woodFloorSound;

    [Header("Concreay floow Audio Sound")]
    [SerializeField]
    private AudioClip[] concreateFloorSound;

    private AudioSource _audio;
    private Animator _ani;
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _ani = GameObject.Find("Player").GetComponent<Animator>();
    }
    void Start()
    {
        
    }
    class soundPlay
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlayFootSound(ref AudioClip[] audioClips, ref AudioSource _audio)
    {
        
        _audio.Play();

    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("wood") ){
             _audio.clip = woodFloorSound[UnityEngine.Random.Range(0, 3)];
        }
    }
}
