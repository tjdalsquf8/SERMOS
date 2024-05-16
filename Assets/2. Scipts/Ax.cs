using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ax : ItemPickUp
{
    public GameObject _Ax;
    public RuntimeAnimatorController axAnimator;
    public RuntimeAnimatorController playerDefaultAnimator;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void SetAx()
    {
        PlayerController.Instance._animator.runtimeAnimatorController = axAnimator;
    }
    public void SetDefault()
    {
        PlayerController.Instance._animator.runtimeAnimatorController = playerDefaultAnimator;
        Instantiate(_Ax, PlayerController.Instance._rightHand.transform.position, PlayerController.Instance._rightHand.transform.rotation);
        this.gameObject.SetActive(false);
    }
}
