//플레이어의 움직임을 물리적으로 계산해서 최종적으로 움직이게 하는 코드
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
        if (characterController.isGrounded) // 캐릭터가 땅에 닿지 않은 경우에만 중력 적용
        {
            verticalSpeed = 0f;
        }
        else
        {
            verticalSpeed += gravity * Time.deltaTime; // 중력 가속도를 수직 속도에 누적
        }
        moveForce.y += (verticalSpeed * 0.14f); // 0.14f 는 중력속도를 조절하기 위한 임의의 수치
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
