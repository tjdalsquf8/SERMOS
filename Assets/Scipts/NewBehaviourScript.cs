using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{ 
    //�յ� �̵�
    private int moveSpeed;
    private float move;
    private float moveVertical;

    //ȸ��
    private int rotSpeed;
    private float rotate;
    private float rotHorizion;

    void Start()
    {
        moveSpeed = 6;
        rotSpeed = 120;
    }

    void Update()
    {
        //�� �� �̵�
        move = moveSpeed * Time.deltaTime;
        moveVertical = Input.GetAxis("Vertical");
        this.transform.Translate(Vector3.forward * move * moveVertical);

        //ȸ��
        rotate = rotSpeed * Time.deltaTime;
        rotHorizion = Input.GetAxis("Horizontal");
        this.transform.Rotate(new Vector3(0.0f, rotate * rotHorizion, 0.0f));
    }
}