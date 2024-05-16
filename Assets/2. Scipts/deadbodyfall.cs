using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadbodyfall : MonoBehaviour
{
    public Rigidbody targerRigidbody;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            targerRigidbody.isKinematic = false;
        }
    }
}
