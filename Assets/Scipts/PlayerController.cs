// ÷  ̾   ¿  ̵     +   ϰ    ȣ ۿ  ϴ   ڵ 
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject _rightHand;

    [Header("Audio clips")]
    [SerializeField]
    private AudioClip audioClipRun;
    [SerializeField]
    private AudioClip[] audioClipWalk;

    private KeyCode keyCodeRun = KeyCode.LeftShift;
    private KeyCode keyCodeJump = KeyCode.Space;
    private KeyCode keyCodeInter = KeyCode.F;
    private RotateToMouse rotateToMouse;
    private MovementCharacterController movement;
    private Status status;
    private AudioSource audioSource;
    private Camera mainCamera;
    //private PlayerAnimatorController animator;
    private Animator _animator;
    public List<GameObject> UiImage = new List<GameObject>();




    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rotateToMouse = GetComponent<RotateToMouse>();
        movement = GetComponent<MovementCharacterController>();
        audioSource = GetComponent<AudioSource>();
        status = GetComponent<Status>();
        mainCamera = Camera.main;
        //animator = GetComponent<PlayerAnimatorController>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   /*
         RayCasting :
        Pick Up : key
        Drop : key
        Open, Close : door_open, box ( tag )
         */
        RayCasting();
        RotateUpdate();
        MoveUpdate();
        // JumpUpdate();

    }

    private void RotateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        rotateToMouse.UpdateRotate(mouseX, mouseY);
    }

    private void MoveUpdate()
    {

        float x = Input.GetAxisRaw("Horizontal"); //     
        float z = Input.GetAxisRaw("Vertical"); //     

        if (x != 0 || z != 0)
        {
            bool IsRun = false;
            if (z > 0) { /*IsRun = Input.GetKey(keyCodeRun);*/ };
            movement.moveSpeed = status.WalkSpeed;

            _animator.SetBool("isWalk", true);
            //animator.MoveSpeed = 0.5f;

        }
        else // x = 0 && z = 0
        {
            movement.moveSpeed = 0;
            _animator.SetBool("isWalk", false);

            //animator.MoveSpeed = 0;

            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }

        if (!movement.characterController.isGrounded)
        {
            audioSource.Stop();
            //animator.MoveSpeed = 0;
        }

        movement.MoveTo(new Vector3(x, 0.0f, z));
    }

    private void JumpUpdate()
    {
        if (Input.GetKey(keyCodeJump))
        {
            movement.Jump();
        }
    }
    private void RayCasting() // Box       ͵      
    {
        Ray ray = mainCamera.ViewportPointToRay(new Vector2(0.5f, 0.5f));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10))
        {
            if (Input.GetKeyDown(keyCodeInter))
            {
                if (hit.collider.CompareTag("door"))
                {
                    Door door = hit.collider.gameObject.GetComponent<Door>();
                    float doorRotationAngle = Quaternion.Angle(door.transform.rotation, Quaternion.identity);
                    //      ȸ        ȸ                            Ͽ    ȯ
                    float distanceX = transform.position.x - hit.transform.position.x;
                    if (doorRotationAngle > 10f) // ȸ    Ͽ  ٸ 
                    {
                        door.SetParams(0);
                    }
                    else if (distanceX > 0) // player          x      Ŭ    
                    {
                        door.SetParams(1);
                    }
                    else
                    {
                        door.SetParams(-1);
                    }

                }
                else if (hit.collider.CompareTag("box"))
                {
                    Box box = hit.collider.GetComponent<Box>();
                    if (box.AniGetBool())
                    {
                        box.AniSetBool(false);
                    }
                    else
                    {
                        box.AniSetBool(true);
                    }
                }
                else if (hit.collider.CompareTag("table"))
                {
                    Table table = hit.collider.GetComponent<Table>();
                    if (table.AniGetBool())
                    {
                        table.AniSetBool(false);
                    }
                    else
                    {
                        table.AniSetBool(true);
                    }
                }
                else if (hit.collider.CompareTag("safebox"))
                {
                    SafeBox safebox = hit.collider.GetComponent<SafeBox>();
                    if (safebox.AniGetBool())
                    {
                        safebox.AniSetBool(false);
                    }
                    else
                    {
                        safebox.AniSetBool(true);
                    }
                }
                else if (hit.collider.CompareTag("concretedoor"))
                {
                    ConcreteDoor concretedoor = hit.collider.GetComponent<ConcreteDoor>();
                    if (concretedoor.AniGetBool())
                    {
                        concretedoor.AniGetBool(false);
                    }
                    else
                    {
                        concretedoor.AniGetBool(true);
                    }
                }
                else if (hit.collider.CompareTag("paper"))
                {
                    Paper paper = hit.collider.GetComponent<Paper>();
                    if (paper != null)
                    {
                        Debug.Log("ui생성");
                        paper.Interact();
                    }
                }

                else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("item"))
                {
                    GameObject heldObject = hit.collider.gameObject;
                    ItemPickUp hitItemPickUp = heldObject.GetComponent<ItemPickUp>();
                    if (hit.collider.CompareTag("key") && !hitItemPickUp.GetIsHolded()) //      Ű   tag  ٲ    
                    {
                        heldObject.transform.SetParent(_rightHand.transform);
                        heldObject.transform.localPosition = Vector3.zero;
                        heldObject.transform.localRotation = Quaternion.identity;
                        heldObject.GetComponent<Rigidbody>().isKinematic = true;
                        hitItemPickUp.SetIsHolded(true);
                    }

                }

                else
                {
                    if (_rightHand.transform.childCount > 0)
                    {
                        DropObject();
                    }

                    UiDelete();
                }
            }
        }
        else if (_rightHand.transform.childCount > 0 && Input.GetKeyDown(keyCodeInter))
        {
            DropObject();
        }
        else
        {
            UiDelete();
        }
    }


    public void UiDelete()
    {
        if (Input.GetKeyDown(keyCodeInter))
        {
            for (int i = 0; i < UiImage.Count; i++)
            {
                if (UiImage[i].activeSelf)
                {
                    UiImage[i].SetActive(false);
                }
            }
        }
    }
    public void PlayFootSound()
    {
        audioSource.clip = audioClipWalk[UnityEngine.Random.Range(0, 3)];
        audioSource.Play();

    }
    public void DropObject() // drop first object in _rightHand 
    {
        Transform firstChild = _rightHand.transform.GetChild(0);
        firstChild.SetParent(null);
        firstChild.GetComponent<Rigidbody>().isKinematic = false;
        firstChild.GetComponent<Rigidbody>().useGravity = true;
        firstChild.GetComponent<ItemPickUp>().SetIsHolded(false);
    }
}