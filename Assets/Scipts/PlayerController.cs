// ÷  ̾   ¿  ̵     +   ϰ    ȣ ۿ  ϴ   ڵ 
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngineInternal;
using System.Runtime.CompilerServices;
using static UnityEngine.UI.Image;
using UnityEngine.SearchService;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject _rightHand;

    [SerializeField]
    private UiController UiController;

    private Camera mainCamera;
    private LineRenderer _lineRenderer;

    Vector3 origin;
    Vector3 direction;

    private bool isUntagged = false;
    private string beforeTag;
    private KeyCode keyCodeRun = KeyCode.LeftShift;
    private KeyCode keyCodeJump = KeyCode.Space;
    private KeyCode keyCodeInter = KeyCode.F;
    private RotateToMouse rotateToMouse;
    private MovementCharacterController movement;
    private Status status;
    private AudioSource audioSource;
    //private PlayerAnimatorController animator;
    private Animator _animator;
    private TaggedObjects _taggedObj;
    
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
        _lineRenderer = GetComponent<LineRenderer>();
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
        Vector3 origin = mainCamera.transform.position;
        Vector3 direction = mainCamera.transform.forward;
        if (Physics.Raycast(ray, out hit, 10))
        {
            _lineRenderer.SetPosition(0, origin);
            _lineRenderer.SetPosition(1, hit.point);
            
            if (hit.collider.CompareTag("door"))
            {
                if (Input.GetKeyDown(keyCodeInter))
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
            }
            else if (hit.collider.CompareTag("box"))
            {

                Box box = null;
                if (box == null)
                {
                    box = hit.collider.GetComponent<Box>();
                }
                if (Input.GetKeyDown(keyCodeInter))
                {
                    if (box.AniGetBool())
                    {
                        box.AniSetBool(false);
                    }
                    else
                    {
                        box.AniSetBool(true);
                    }
                }
                // if (box != null && !box.AniGetBool()) StartCoroutine(UiController.FadeInOut("Open the box", UiController.UiState.PlayerUi, true));
                // else if (box != null && box.AniGetBool()) StartCoroutine(UiController.FadeInOut("Close the box", UiController.UiState.PlayerUi, true));
            }
            else if (hit.collider.CompareTag("table"))
            {
                Table table = null;
                if (table == null) table = hit.collider.GetComponent<Table>();
                if (Input.GetKeyDown(keyCodeInter))
                {
                    if (table.AniGetBool())
                    {
                        UiController.SetTextGUI((int)UiController.ObjectTags.table);
                        table.AniSetBool(false);
                    }
                    else
                    {
                        UiController.SetTextGUI((int)UiController.ObjectTags.table + 1);
                        table.AniSetBool(true);
                    }
                }
                if (table != null && !table.AniGetBool())
                {
                    UiController.SetTextGUI((int)UiController.ObjectTags.table);
                }
                else if (table != null && table.AniGetBool())
                {
                    UiController.SetTextGUI((int)UiController.ObjectTags.table + 1);
                }
            }
            // table end 
            else if (hit.collider.CompareTag("safebox"))
            {
                SafeBox safebox = null;
                if (safebox == null) safebox = hit.collider.GetComponent<SafeBox>();
                if (Input.GetKeyDown(keyCodeInter))
                {
                    if (safebox.AniGetBool())
                    {
                        safebox.AniSetBool(false);
                    }
                    else
                    {
                        safebox.AniSetBool(true);
                    }
                }
                if (safebox != null && !safebox.AniGetBool()) { }
                else if (safebox != null && safebox.AniGetBool()) { }
            }
            else if (hit.collider.CompareTag("concretedoor"))
            {
               
                ConcreteDoor concreatdoor = null;
                if (concreatdoor == null) concreatdoor = hit.collider.GetComponent<ConcreteDoor>();

                if (Input.GetKeyDown(keyCodeInter))
                {
                    if (concreatdoor.AniGetBool())
                    {
                        concreatdoor.AniGetBool(false);
                    }
                    else
                    {
                        concreatdoor.AniGetBool(true);
                    }
                }
                if (concreatdoor != null && !concreatdoor.AniGetBool()) { }
                else if (concreatdoor != null && concreatdoor.AniGetBool()) { }
            }
            else if (hit.collider.CompareTag("griddoor"))
            {
                GridDoor griddoor = null;
                if (griddoor == null) griddoor = hit.collider.GetComponent<GridDoor>();

                if (Input.GetKeyDown(keyCodeInter))
                {
                    GameObject firstChild = null;
                    if (firstChild == null && _rightHand.transform.childCount > 0) firstChild = _rightHand.transform.GetChild(0).gameObject;
                    if (firstChild != null && firstChild.CompareTag("key"))
                    {
                        ItemPickUp key = firstChild.GetComponent<ItemPickUp>();
                        if (key.GetKeyKind() == ItemPickUp.KeyKind.under && key.GetIsHolded() == true) // key가 지하실 key이고, 가지고 잇을때,
                        {
                            griddoor.AniSetBool(true);
                            key.SetIsUsed(true);
                            key.SetIsHolded(false);
                        }
                    }
                    else if (firstChild == null) griddoor.AniSetBool(false);
                }
            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("item"))
            {
                UiController.SetTextGUI((int)UiController.ObjectTags.key);
                if (Input.GetKeyDown(keyCodeInter))
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
            }
            else if (hit.collider.CompareTag("paper"))
            {
               
                Paper paper = hit.collider.GetComponent<Paper>();
                if (paper != null && Input.GetKeyDown(keyCodeInter))
                {
                    paper.Interact();
                }
            }
            else // raycast find object but, tag is Untagged
            {
                UiController.SetTextGUI(-1);

                if (_rightHand.transform.childCount > 0 && Input.GetKeyDown(keyCodeInter))
                {
                    DropObject();
                }
                //UiController.UiDelete(); ! game resource down
            }
            }
            else if (_rightHand.transform.childCount > 0 && Input.GetKeyDown(keyCodeInter)) // raycast cant find obj
            {
                DropObject();
            }
            else
            {
            UiController.SetTextGUI(-1);
           
            }
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