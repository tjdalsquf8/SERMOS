//�÷��̾��� �������� ���������� ����ؼ� ���������� �����̰� �ϴ� �ڵ�
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementCharacterController : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed;
    private Vector3 moveForce;

    private static bool IsRun = false;

    private float gravity = -9.8f;
    private float verticalSpeed = 0f;
    private float jumpPower = 17.0f;
    public CharacterController characterController;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded) // ĳ���Ͱ� ���� ���� ���� ��쿡�� �߷� ����
        {
            verticalSpeed = 0f;
        }
        else
        {
            verticalSpeed += gravity * Time.deltaTime; // �߷� ���ӵ��� ���� �ӵ��� ����
        }
        moveForce.y += (verticalSpeed * 0.14f); // 0.14f �� �߷¼ӵ��� �����ϱ� ���� ������ ��ġ
        characterController.Move(moveForce * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        direction = transform.rotation * new Vector3(direction.x, 0, direction.z);
        moveForce = new Vector3(direction.x * moveSpeed, moveForce.y, direction.z * moveSpeed);
    }
    public void Jump()
    {
        if (characterController.isGrounded)
        {
            moveForce.y = jumpPower;
        }
    }

    public bool CheckIsRun
    {
        get { return IsRun; }
    }

}
