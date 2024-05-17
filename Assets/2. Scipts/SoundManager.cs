using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public AudioClip fallSound; // ����� ����� Ŭ��

    void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� ����͸� ����Ʈ�� �ִ��� Ȯ��
        {
            if (!collision.collider.CompareTag("Player"))
            {
            // �浹 �������� �Ҹ��� ���
            Vector3 collisionPoint = collision.contacts[0].point;
            AudioSource.PlayClipAtPoint(fallSound, collisionPoint);
            Debug.Log("�Ҹ� ���");

            }
        }
    }
}
