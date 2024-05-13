using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

//���(agent=enemy)���� �������� �˷��༭ �������� �̵��ϰ� �Ѵ�.
//���¸� ���� �����ϰ� �ʹ�.
// Idle : Player�� ã�´�, ã������ Run���·� �����ϰ� �ʹ�.
//Run : Ÿ�ٹ������� �̵�(���)
//Attack : ���� �ð����� ����

public class Enemy : MonoBehaviour
{

    //������
    public Transform target;
    //���
    NavMeshAgent agent;

    private Animator anim;
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] audioClipWalk;

    private bool isAttacked = false;
    //���������� ������ ���°��� ���
    enum State
    {
        Idle,
        Walk,
        Attack,
        Run
    }
    //���� ó��
    State state;

    // Start is called before the first frame update
    void Start()
    {
        //������ ���¸� Idle�� �Ѵ�.
        state = State.Idle;

        //����� �������༭
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //���� state�� idle�̶��
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
        // �ִϸ��̼� ��� -> �ִϸ��̼� �ٲٱ�
        // ������ Ÿ�ֿ̹� player �ִϸ��̼� ���
        // player �������� �ִϸ��̼� -> �������� �ִϸ��̼� ���ؼ� ���� ���Ѻ���
        // fade in -> game over
    }

    private void UpdateWalk ()
    {


        //���� �Ÿ��� 2���Ͷ�� �����Ѵ�.
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= 5 && !anim.GetBool("isAttack"))
        {
            state = State.Attack;
        }

        //Ÿ�� �������� �̵��ϴٰ�
        agent.speed = 3.5f;
        anim.SetBool("isWalking", true);
       
        
        //������� �������� �˷��ش�.
        agent.destination = target.transform.position;

    }

    private void UpdateIdle()
    {
        agent.speed = 0;
        anim.SetBool("isWalking", false);
        //�����ɶ� ������(Player)�� �O�´�.
        target = GameObject.Find("Player").transform;
        //target�� ã���� Run���·� �����ϰ� �ʹ�.
        if (target != null && !isAttacked)
        {
            state = State.Walk;
            //�̷��� state���� �ٲ�ٰ� animation���� �ٲ��? no! ����ȭ�� ������Ѵ�.
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
