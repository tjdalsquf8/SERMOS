using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

//요원(agent=enemy)에게 목적지를 알려줘서 목적지로 이동하게 한다.
public class Priest : MonoBehaviour
{
    //목적지
    public Transform target;
    //요원
    NavMeshAgent agent;
    private Animator _animation;
    // Start is called before the first frame update
    private void Awake()
    {
    }
    void Start()
    {
        //요원을 정의해줘서
        agent = GetComponent<NavMeshAgent>();
        //생성될때 목적지(Player)를 찿는다.
        target = GameObject.Find("Player").transform;
        //요원에게 목적지를 알려준다.
        agent.destination = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

}