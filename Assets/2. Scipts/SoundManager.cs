using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public AudioClip fallSound; // 재생할 오디오 클립
    private int collisioncount = 0;
   
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
        if ( collisioncount >= 1)
        {
        // 충돌 지점에서 소리를 재생
            Vector3 collisionPoint = collision.contacts[0].point;
            AudioSource.PlayClipAtPoint(fallSound, collisionPoint);
            collisioncount++;
        }
        else
        {
            collisioncount++;
        }
       
    }
}
