using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    public Animator animator; // �ִϸ����� ������Ʈ
    private float moveSpeed; // �̵� �ӵ�
    public float speed = 1f; // �߰����� �ӵ� ���� ����
    private float waitTime = 0f; // ��� �ð� ���� ����
    public float waitDuration = 5f; // ��� �ð� (�� ����)

    private void Start()
    {
        animator = GetComponent<Animator>(); // �ִϸ����� ������Ʈ�� ������
    }

    private void Update()
    {
        waitTime += Time.deltaTime; // ��� �ð� ������Ʈ
        if (waitTime > waitDuration)
        {
            // �̵� �ӵ��� ������Ʈ
            moveSpeed = Time.deltaTime * speed;

            // �÷��̾��� ��ġ�� ������ �̵�
            transform.Translate(Vector3.forward * moveSpeed);
        }
    }
}
