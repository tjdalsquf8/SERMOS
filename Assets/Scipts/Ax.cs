using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ax : ItemPickUp
{

    public GameObject ax;
    public RuntimeAnimatorController axAnimator;
    public RuntimeAnimatorController playerDefaultAnimator;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void SetAx()
    {
            PlayerController.Instance._animator.runtimeAnimatorController = playerDefaultAnimator; // ? � object�� null���� ������
    }
}
