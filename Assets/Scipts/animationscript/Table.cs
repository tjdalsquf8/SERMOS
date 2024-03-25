using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : TaggedObjects
{
    // private bool isRayCated = false;
    /*public void SetIsRayCasted(bool value)
    {
        _isRaycasted = value;
    }*/
    Animator _animator;
    [SerializeField]
    private AudioClip _openSound;
    private  AudioSource _audio;
    private string _isClose = "Open the drawer";
    private string _isOpen = "Close the drawer";
    private bool _currentIsOpen;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
    }
    private void Start()
    {
        _audio.clip = _openSound;
    }
    // Update is called once per frame


    public void AniSetBool(bool isOpen)
    {
        
       // StartCoroutine(PlayGridDoorSounds());
        _animator.SetBool("isOpen", isOpen);
       // StopCoroutine(PlayGridDoorSounds());
    }
    public bool AniGetBool() {
        return _animator.GetBool("isOpen"); 

    }
   /* private IEnumerator PlayGridDoorSounds() why this code in table.cs ?
    {
        _audio.Play();
        yield return new WaitForSeconds(_audio.clip.length);
    }
*/
   /* public void SetIsRayCasted(bool value)
    {
        _isRaycasted = value;
    }*/
}
