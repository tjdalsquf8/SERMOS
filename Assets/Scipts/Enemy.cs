using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

//요원(agent=enemy)에게 목적지를 알려줘서 목적지로 이동하게 한다.
//상태를 만들어서 제어하고 싶다.
// Idle : Player를 찾는다, 찾았으면 Run상태로 전이하고 싶다.
//Run : 타겟방향으로 이동(요원)
//Attack : 일정 시간마다 공격

public class Enemy : MonoBehaviour
{

    //목적지
    public Transform target;
    //요원
    NavMeshAgent agent;

    private Animator anim;
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] audioClipWalk;

    private bool isAttacked = false;
    //열거형으로 정해진 상태값을 사용
    enum State
    {
        Idle,
        Walk,
        Attack,
        Run
    }
    //상태 처리
    State state;

    // Start is called before the first frame update
    void Start()
    {
        //생성시 상태를 Idle로 한다.
        state = State.Idle;

        //요원을 정의해줘서
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //만약 state가 idle이라면
        if (state == State.Idle)
        {
            UpdateIdle();
        }
        else if (state == State.Walk)
        {
            UpdateWalk();
        } else if(state == State.Attack)
        {
            UpdateAttack();
        }
        

    }

    private void UpdateAttack()
    {
        agent.speed = 0;
        anim.SetBool("isAttack", true);
        PlayerController.Instance.setIsDied(true);
        // 애니매이션 재생 -> 애니매이션 바꾸기
        // 때리는 타이밍에 player 애니매이션 재생
        // player 쓰러지는 애니매이션 -> 쓰러지는 애니매이션 구해서 적용 시켜보기
        // fade in -> game over
    }

    private void UpdateWalk ()
    {


        //남은 거리가 2미터라면 공격한다.
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= 5 && !anim.GetBool("isAttack"))
        {
            state = State.Attack;
        }

        //타겟 방향으로 이동하다가
        agent.speed = 3.5f;
        anim.SetBool("isWalking", true);
       
        
        //요원에게 목적지를 알려준다.
        agent.destination = target.transform.position;

    }

    private void UpdateIdle()
    {
        agent.speed = 0;
        anim.SetBool("isWalking", false);
        //생성될때 목적지(Player)를 찿는다.
        target = GameObject.Find("Player").transform;
        //target을 찾으면 Run상태로 전이하고 싶다.
        if (target != null && !isAttacked)
        {
            state = State.Walk;
            //이렇게 state값을 바꿨다고 animation까지 바뀔까? no! 동기화를 해줘야한다.
            //anim.SetTrigger("Run");
        }
    }

    public void PlayWalkSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = audioClipWalk[UnityEngine.Random.Range(0, 3)];
        }
        if (audioSource.enabled)
        {
            audioSource.Play();
        }
        
    }

    public void PlayerAnimHit()
    {
        PlayerController.Instance.setAnimIsHited();
    }

    public void SetStateIdle()
    {
        isAttacked = true;
        anim.SetBool("isWaling", false);
        state = State.Idle;
    }
}
