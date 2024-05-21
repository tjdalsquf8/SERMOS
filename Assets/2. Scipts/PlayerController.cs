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
using Unity.VisualScripting;
using UnityEditor.Animations;
using DoorScript;
using Autodesk.Fbx;
using static UnityEngine.Rendering.DebugUI;

public class PlayerController : MonoBehaviour
{
    private int  layerMask                   = 1;
    private bool isEquipAx                   = false;
    private bool isDied                      = false;
    private bool canReceiveInput             = false;

    [Header("Breaking woods")]
    [SerializeField]
    private BreakingWood[] woods;

    [SerializeField]
    private GameObject InputInspector_rightHand;

    [Header("Main Camera")]
    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private AudioClip hitTheFloor;
    public static PlayerController Instance { get; private set; }
    public GameObject _rightHand { get; private set; }
    public Animator _animator { get ; private set; }

  

    public GameObject _rightHand_ax;
    private KeyCode keyCodeRun               = KeyCode.LeftShift;
    private KeyCode keyCodeJump              = KeyCode.Space;
    private KeyCode keyCodeInter             = KeyCode.F;
    private RotateToMouse rotateToMouse;
    private MovementCharacterController movement;
    private Status status;
    private AudioSource audioSource;
    private Ax _rightHandAxScript;
    //private PlayerAnimatorController animator;


    //fade out
    public Image Panel;
    float time = 0f;
    float F_time = 1f;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rotateToMouse = GetComponent<RotateToMouse>();
        movement = GetComponent<MovementCharacterController>();
        audioSource = GetComponent<AudioSource>();
        status = GetComponent<Status>();
        _animator = GetComponent<Animator>();
        //animator = GetComponent<PlayerAnimatorController>();
       layerMask = 1 << LayerMask.NameToLayer("Ignore Raycast");
        _rightHandAxScript = _rightHand_ax.GetComponent<Ax>();
        Instance = GetComponent<PlayerController>();
        _rightHand = InputInspector_rightHand;
    }

    void Update()
    {   /*
         RayCasting :
        Pick Up : key
        Drop : key
        Open, Close : door_open, box ( tag )
         */
        RayCasting();

        if (canReceiveInput)
        {
            RotateUpdate();
            MoveUpdate();
        }
       
        // JumpUpdate();
        
    }

    private void RotateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        if (isDied)
        {
            mouseX = 0;
            mouseY = 0;
            return;
        }
        rotateToMouse.UpdateRotate(mouseX, mouseY);
    }

    private void MoveUpdate()
    {
       

        float x = Input.GetAxisRaw("Horizontal"); //     
        float z = Input.GetAxisRaw("Vertical"); //
        if (isDied)
        {
            x = 0;
            z = 0;
            _animator.SetBool("isWalk", false);
            CharacterController cc = GetComponent<CharacterController>();
            cc.enabled = false;
            return;
        }
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

            /*if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }*/
        }

      /*  if (!movement.characterController.isGrounded)
        {
            audioSource.Stop();
            //animator.MoveSpeed = 0;
        }*/

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
            if (hit.collider.CompareTag("door"))
            {
                Door door = null;
                if (door == null) door = hit.collider.gameObject.GetComponent<Door>();
                if (Input.GetKeyDown(keyCodeInter) && door)
                {
                   
                    float doorRotationAngle = Quaternion.Angle(door.transform.rotation, Quaternion.identity);
                    //      ȸ        ȸ                            Ͽ    ȯ
                    float distanceX = transform.position.x - hit.transform.position.x;
                    if (doorRotationAngle > 10f) // ȸ    Ͽ  ٸ 
                    {
                        door.SetParams(0);
                        UiController.Instance.SetTextGUI((int)UiController.ObjectTags.door);
                    }
                    else if (distanceX > 0) // player          x      Ŭ    
                    {
                        door.SetParams(1);
                        UiController.Instance.SetTextGUI((int)UiController.ObjectTags.door + 1);
                    }
                    else
                    {
                        door.SetParams(-1);
                        UiController.Instance.SetTextGUI((int)UiController.ObjectTags.door + 1);
                    }

                }
                if(door != null && !door.GetIsopened()) UiController.Instance.SetTextGUI((int)UiController.ObjectTags.door );
                else if(door != null && door.GetIsopened()) UiController.Instance.SetTextGUI((int)UiController.ObjectTags.door +1);
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
                        UiController.Instance.SetTextGUI((int)UiController.ObjectTags.box);
                        box.AniSetBool(false);
                    }
                    else
                    {
                        UiController.Instance.SetTextGUI((int)UiController.ObjectTags.box + 1);
                        box.AniSetBool(true);
                    }
                }
                if (box != null && !box.AniGetBool())
                {
                    UiController.Instance.SetTextGUI((int)UiController.ObjectTags.box);
                }
                else if (box != null && box.AniGetBool())
                {
                    UiController.Instance.SetTextGUI((int)UiController.ObjectTags.box + 1);
                }
            }
            else if (hit.collider.CompareTag("table"))
            {
                Table table = null;
                if (table == null) table = hit.collider.GetComponent<Table>();
                if (Input.GetKeyDown(keyCodeInter))
                {
                    if (table.AniGetBool())
                    {
                        UiController.Instance.SetTextGUI((int)UiController.ObjectTags.table);
                        table.AniSetBool(false);
                    }
                    else
                    {
                        UiController.Instance.SetTextGUI((int)UiController.ObjectTags.table + 1);
                        table.AniSetBool(true);
                    }
                }
                if (table != null && !table.AniGetBool())
                {
                    UiController.Instance.SetTextGUI((int)UiController.ObjectTags.table);
                }
                else if (table != null && table.AniGetBool())
                {
                    UiController.Instance.SetTextGUI((int)UiController.ObjectTags.table + 1);
                }
            }
        
            else if (hit.collider.CompareTag("safebox"))
            {
                SafeBox safebox = null;
                if (safebox == null) safebox = hit.collider.GetComponent<SafeBox>();
                if (Input.GetKeyDown(keyCodeInter))
                {
                    if (safebox.AniGetBool())
                    {
                        UiController.Instance.SetTextGUI((int)UiController.ObjectTags.box);
                        safebox.AniSetBool(false);
                    }
                    else
                    {
                        UiController.Instance.SetTextGUI((int)UiController.ObjectTags.box+1);
                        safebox.AniSetBool(true);
                    }
                }
                if (safebox != null && !safebox.AniGetBool()) {
                    UiController.Instance.SetTextGUI((int)UiController.ObjectTags.box);
                }
                else if (safebox != null && safebox.AniGetBool()) {
                    UiController.Instance.SetTextGUI((int)UiController.ObjectTags.box + 1);
                }
            }
            else if (hit.collider.CompareTag("concretedoor"))
            {
               
                ConcreteDoor concreatdoor = null;
                if (concreatdoor == null) concreatdoor = hit.collider.GetComponent<ConcreteDoor>();

                if (Input.GetKeyDown(keyCodeInter))
                {
                    if (concreatdoor.AniGetBool())
                    {
                        UiController.Instance.SetTextGUI((int)UiController.ObjectTags.concretedoor);
                        concreatdoor.AniGetBool(false);
                    }
                    else
                    {
                        UiController.Instance.SetTextGUI((int)UiController.ObjectTags.concretedoor+ 1);
                        concreatdoor.AniGetBool(true);
                    }
                }
                if (concreatdoor != null && !concreatdoor.AniGetBool()) {
                    UiController.Instance.SetTextGUI((int)UiController.ObjectTags.concretedoor);
                }
                else if (concreatdoor != null && concreatdoor.AniGetBool()) {
                    UiController.Instance.SetTextGUI((int)UiController.ObjectTags.concretedoor + 1);
                }
            }
            else if (hit.collider.CompareTag("griddoor"))
            {
                GridDoor griddoor = null;
                if (griddoor == null) griddoor = hit.collider.GetComponent<GridDoor>();

                if (Input.GetKeyDown(keyCodeInter))
                {
                    GameObject firstChild = null;
                    if (firstChild == null && _rightHand.transform.childCount > 1)
                    {
                        firstChild = _rightHand.transform.GetChild(1).gameObject;
                    }
                    else
                    {
                        UiController.Instance.GridDoorOpenNotPossible();
                    }
                    if (firstChild != null && firstChild.CompareTag("key"))
                    {
                        ItemPickUp key = firstChild.GetComponent<ItemPickUp>();
                        if (key.GetKeyKind() == ItemPickUp.ObjKind.under && key.GetIsHolded() == true) // key가 지하실 key이고, 가지고 잇을때,
                        {
                            griddoor.AniSetBool(true);
                            key.SetIsHolded(false);
                            key.SetIsUsed(true);
                        }
                    }
                    else if (firstChild == null) griddoor.AniSetBool(false);
                }
                if (griddoor != null && !griddoor.AniGetBool())
                {
                    UiController.Instance.SetTextGUI((int)UiController.ObjectTags.door);
                }
            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("item")
                && _rightHand.transform.childCount < 2)
            {
                UiController.Instance.SetTextGUI((int)UiController.ObjectTags.item);
                if (Input.GetKeyDown(keyCodeInter))
                {
                    GameObject heldObject = hit.collider.gameObject;
                    ItemPickUp hitItemPickUp = heldObject.GetComponent<ItemPickUp>();
                    if (!hit.collider.CompareTag("Ax") && !hitItemPickUp.GetIsHolded() ) //  if not holed
                    {
                        heldObject.transform.SetParent(_rightHand.transform);
                        heldObject.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
                        heldObject.GetComponent<Rigidbody>().isKinematic = true;
                        MeshCollider mesh = heldObject.GetComponent<MeshCollider>();
                        if (mesh != null)
                        {
                            mesh.enabled = false;
                        }
                        hitItemPickUp.SetIsHolded(true);
                    }

                    if (hit.collider.CompareTag("Ax")) // animation status change And isEquipAx save true
                    {
                        _rightHand_ax.SetActive(true);
                        _animator.SetBool("haveAx", true);
                        _rightHandAxScript.SetAx();
                        isEquipAx = true;
                        Destroy(hit.collider.gameObject);
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
                if (paper != null && !paper.enabled)
                {
                    UiController.Instance.SetTextGUI((int)UiController.ObjectTags.paper);
                }
            }
            else if (hit.collider.CompareTag("Radio"))
            {
                Radio radio = null;
                if (radio == null) radio = hit.collider.GetComponent<Radio>();
                if (radio != null)
                {
                    UiController.Instance.SetTextGUI((int)UiController.ObjectTags.radio);
                }
                if (radio != null && Input.GetKeyDown(keyCodeInter)) {
                    Transform battery;
                    if(Radio.batteryCount == 2)
                    {
                        radio.AudioPlay();
                    }
                    else if (_rightHand.transform.childCount < 2)
                    {
                       UiController.Instance.RadioPlaybackNoyPossible();
                    }else if(_rightHand.transform.childCount > 1)
                    {
                        battery = _rightHand.transform.GetChild(1);
                        Battery battery_script = battery.GetComponent<Battery>();
                        if (battery == null || battery_script == null)
                        {
                            UiController.Instance.RadioPlaybackNoyPossible();
                        }
                        else if (battery != null && battery_script != null)
                        {
                            battery_script.SetIsUsed(true);
                            battery_script.SetIsHolded(false);
                        }
                        
                    }
                }
            }
            else if(isEquipAx && hit.collider.CompareTag("BreakingWood"))
            {
                UiController.Instance.SetTextGUI((int)UiController.ObjectTags.breakingWood);
                if(Input.GetKeyDown(keyCodeInter))
                {
                    //BreakingWoods(); // after delete, when all ready animations
                    _animator.SetBool("isAttack", true);
                }
            }
            else if (hit.collider.CompareTag("MasterDoor"))
            {
                DoorScript.Door masterDoor = null;
                if (masterDoor == null) masterDoor = hit.collider.GetComponent<DoorScript.Door>();
                if (Input.GetKeyDown(keyCodeInter))
                {
                    GameObject firstChild = null;
                    if (firstChild == null && _rightHand.transform.childCount > 1)
                    {
                        firstChild = _rightHand.transform.GetChild(1).gameObject;
                    }
                    else
                    {
                        UiController.Instance.GridDoorOpenNotPossible();
                    }
                    if (firstChild != null && firstChild.CompareTag("key"))
                    {
                        ItemPickUp key = firstChild.GetComponent<ItemPickUp>();
                        if (key.GetKeyKind() == ItemPickUp.ObjKind.master && key.GetIsHolded() == true) // key가 지하실 key이고, 가지고 잇을때,
                        {
                            masterDoor.OpenDoor();
                        }
                    }
                   // else if (firstChild == null)
                }
                if (!masterDoor.open) UiController.Instance.SetTextGUI((int)UiController.ObjectTags.door);
                else UiController.Instance.SetTextGUI((int)UiController.ObjectTags.door + 1);
            }
            else // raycast find object but, tag is Untagged
            {
                UiController.Instance.SetTextGUI(-1);

                if (_rightHand.transform.childCount > 0 && Input.GetKeyDown(keyCodeInter))
                {
                    DropObject();
                }
                //UiController.UiDelete(); ! game resource down
            }
            }
            else if (_rightHand.transform.childCount > 1 && Input.GetKeyDown(keyCodeInter)) // raycast cant find obj
            {
                DropObject();
            }
            else
            {
                UiController.Instance.SetTextGUI(-1);
            }
    }
    public void DropObject() // drop first object in _rightHand 
    {
        Transform firstChild = 
            _rightHand.transform.childCount > 1 ? // have two childs obj 
            _rightHand.transform.GetChild(1) : _rightHand.transform.GetChild(0);
        if (firstChild.CompareTag("Ax"))
        {
            if (isEquipAx == false) return;
            isEquipAx = false;
            _animator.SetBool("haveAx", false);
            _rightHandAxScript.SetDefault();
            return;
        }
        Rigidbody rb = firstChild.GetComponent<Rigidbody>(); 
        firstChild.SetParent(null);
        rb.isKinematic = false;
        rb.useGravity = true;
        firstChild.GetComponent<Collider>().enabled = true;
        firstChild.GetComponent<ItemPickUp>().SetIsHolded(false);
    }
    private void SetIsAttackFalse()
    {
        _animator.SetBool("isAttack", false);
    }
    private void BreakingWoods() // Make animation event in HeavyWeaponSwing
    {
        for (int i = 0; i < 2; i++)
        {
            woods[i].SetisBreaked(true);
        }
    }

    public void setIsDied(bool value)
    {
        isDied = value;
    }
   
    public void setAnimIsHited()
    {
        _animator.SetBool("isHited", true);
    }

   public void HitTheFloorDied()
    {
        audioSource.clip = hitTheFloor;
        audioSource.Play();
    }

    public void CanRotCameraAndMovePlayer()
    {
        canReceiveInput = true;
    }

    public void PlayerDieFadeOut()
    {
        // fade out
        // LoadScene
        StartCoroutine(FadeFlow());

        IEnumerator FadeFlow()
        {
            Panel.gameObject.SetActive(true);
            Color alpha = Panel.color;

            while (alpha.a < 1f)
            {
                time += Time.deltaTime / F_time;
                alpha.a = Mathf.Lerp(0, 1, time);
                Panel.color = alpha;
                yield return null;
            }
            yield return null;
            SceneManager.LoadScene("GameOverScene");
        }
    }

}