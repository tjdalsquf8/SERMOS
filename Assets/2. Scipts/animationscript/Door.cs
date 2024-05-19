using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    protected bool _isRotated = false;
    protected int _param = 0;
    protected Animator _animator;
    [SerializeField]
    protected AudioClip _openSound;
    [SerializeField]
    protected AudioClip _closeSound;
    public Animator _cousionanimator;
    

    protected  AudioSource audio;
    protected void Awake()
    {
        _animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }
    protected void Start()
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

    public bool GetIsopened() // 열려 있는 상태를 return해서 player controller에서 추가구현
    {
        return _animator.GetBool("isOpen") || _animator.GetBool("isNegOpen");
    }
}