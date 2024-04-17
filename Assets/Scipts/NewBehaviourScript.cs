using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{ 
    //앞뒤 이동
    private int moveSpeed;
    private float move;
    private float moveVertical;

    //회전
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
        //앞 뒤 이동
        move = moveSpeed * Time.deltaTime;
        moveVertical = Input.GetAxis("Vertical");
        this.transform.Translate(Vector3.forward * move * moveVertical);

        //회전
        rotate = rotSpeed * Time.deltaTime;
        rotHorizion = Input.GetAxis("Horizontal");
        this.transform.Rotate(new Vector3(0.0f, rotate * rotHorizion, 0.0f));
    }
}