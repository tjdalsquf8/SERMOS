using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public AudioClip fallSound; // ����� ����� Ŭ��
    private int collisioncount = 0;

    void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� ����͸� ����Ʈ�� �ִ��� Ȯ��
        {
            if (!collision.collider.CompareTag("Player") && collisioncount==0)
            {
            // �浹 �������� �Ҹ��� ���
            Vector3 collisionPoint = collision.contacts[0].point;
            AudioSource.PlayClipAtPoint(fallSound, collisionPoint);
                collisioncount++;
            }
        }
    }
}
