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
        // 충돌한 오브젝트가 모니터링 리스트에 있는지 확인
        {
            if (!collision.collider.CompareTag("Player") && collisioncount==0)
            {
            // 충돌 지점에서 소리를 재생
            Vector3 collisionPoint = collision.contacts[0].point;
            AudioSource.PlayClipAtPoint(fallSound, collisionPoint);
                collisioncount++;
            }
        }
    }
}
