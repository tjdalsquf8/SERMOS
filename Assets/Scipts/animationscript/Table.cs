using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame


    public void AniSetBool(bool isOpen)
    {
        _animator.SetBool("isOpen", isOpen);
    }
    public bool AniGetBool() { return _animator.GetBool("isOpen"); }
}
