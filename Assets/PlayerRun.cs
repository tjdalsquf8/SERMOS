using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    public Animator animator; // 애니메이터 컴포넌트
    private float moveSpeed; // 이동 속도
    public float speed = 1f; // 추가적인 속도 조정 변수
    private float waitTime = 0f; // 대기 시간 추적 변수
    public float waitDuration = 5f; // 대기 시간 (초 단위)

    private void Start()
    {
        animator = GetComponent<Animator>(); // 애니메이터 컴포넌트를 가져옴
    }

    private void Update()
    {
        waitTime += Time.deltaTime; // 대기 시간 업데이트
        if (waitTime > waitDuration)
        {
            // 이동 속도를 업데이트
            moveSpeed = Time.deltaTime * speed;

            // 플레이어의 위치를 앞으로 이동
            transform.Translate(Vector3.forward * moveSpeed);
        }
    }
}
