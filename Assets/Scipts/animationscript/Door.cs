using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool _isRotated = false;
    private int _param = 0;
    private Animator _animator;
    [SerializeField]
    private AudioClip _openSound;
    [SerializeField]
    private AudioClip _closeSound;
    public Animator _cousionanimator;
    

    private AudioSource audio;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }
    private void Start()
    {
        audio.clip = _openSound;
    }
    public void SetParams(int i) // -1, 0, 1
    {
        _param = i;

        if (_param == 1 || _param == -1)
        {
            if (_param == 1)
            {
                _animator.SetBool("isOpen", true);
            
            }
            else if (_param == -1)
            {
                _animator.SetBool("isNegOpen", true);

                if (_cousionanimator != null)
                {
                    _cousionanimator.SetBool("isfall", true);
                }
            }
            audio.Stop();
            audio.clip = _openSound;
            audio.pitch = 1.8f;
            audio.Play();
        }
        else if (_param == 0)
        {
            if (transform.rotation.y > 0f)
            {
                _animator.SetBool("isOpen", false);
            }
            else if (transform.rotation.y < 0f)
            {
                _animator.SetBool("isNegOpen", false);
            }
                audio.Stop();
                audio.clip = _closeSound;
                audio.pitch = 0.9f;
                audio.Play();
            /*            AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
                        if (!stateInfo.IsName("ClosePos") || !stateInfo.IsName("CloseNeg"))
                        {
                        }*/
        }
    }

    public int GetParams()
    {
        return _param;
    }

    public void ToggleRotation()
    {
        _isRotated = !_isRotated;
    }
}