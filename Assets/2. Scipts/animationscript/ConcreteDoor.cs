using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteDoor : MonoBehaviour
{
    Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void AniGetBool(bool isOpen)
    {
        _animator.SetBool("isOpen", isOpen);
    }

    public bool AniGetBool()
    {
        return _animator.GetBool("isOpen");
    }
}
