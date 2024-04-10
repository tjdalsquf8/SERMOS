using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BreakingWood : MonoBehaviour
{
    private const int partSize = 2;
    [SerializeField]
    private GameObject door;

    private Rigidbody _rb;

    private bool isBreaked = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isBreaked)
        {
            _rb.isKinematic = false;
            _rb.AddForce( 20 * Vector3.right, ForceMode.Impulse);
            door.transform.tag = "door";
            isBreaked = false;
            this.enabled = false;
        }
    }
 

    public void SetisBreaked(bool value)
    {
        isBreaked = value;
        return;
    }
}
