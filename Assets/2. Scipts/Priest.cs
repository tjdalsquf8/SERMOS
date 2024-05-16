using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

//���(agent=enemy)���� �������� �˷��༭ �������� �̵��ϰ� �Ѵ�.
public class Priest : MonoBehaviour
{
    //������
    public Transform target;
    //���
    NavMeshAgent agent;
    private Animator _animation;
    // Start is called before the first frame update
    private void Awake()
    {
    }
    void Start()
    {
        //����� �������༭
        agent = GetComponent<NavMeshAgent>();
        //�����ɶ� ������(Player)�� �O�´�.
        target = GameObject.Find("Player").transform;
        //������� �������� �˷��ش�.
        agent.destination = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

}