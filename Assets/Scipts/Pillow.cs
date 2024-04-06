using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pillow : ItemPickUp
{
   private  const ObjKind objkind = ObjKind.pillow;
     private const string ignoreRaycast_layerName = "Ignore Raycast";
    private const string item_layerName = "item";
    private  int iR_layerIndex;
    private  int item_layerIndex;
    [SerializeField]
    private UiController uicontroller;
    private Rigidbody rb;
    private Animator _ani;

    MeshCollider _mesh;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
        _ani = GetComponent<Animator>();   
       _mesh = GetComponent<MeshCollider>();
        iR_layerIndex = LayerMask.NameToLayer(ignoreRaycast_layerName);
        item_layerIndex = LayerMask.NameToLayer(item_layerName);
    }
    private void Start()
    {
        rb.useGravity = false;
    }
    private void Update()
    {
        if (isHolded)
        {
            uicontroller.SetTextGUI((int)UiController.ObjectTags.pillow);
            if (this.gameObject.layer != iR_layerIndex) this.gameObject.layer = iR_layerIndex;
        }
        else
        {
            if (this.gameObject.layer != item_layerIndex) this.gameObject.layer = item_layerIndex;
        }
            
        if (isHolded && Input.GetMouseButtonDown(0))
        {
            if (!_mesh.enabled)
            {
                _mesh.enabled = true;
            }
            this.transform.SetParent(null);
            rb.isKinematic = false;
            rb.useGravity = true;
            this.SetIsHolded(false);
            rb.AddForce(Vector3.forward * 10, ForceMode.Impulse);
        }
        
        if (_ani.GetBool("isfall"))
        {
            rb.useGravity = true;
        }
    }

    public void GetIsused()
    {
        return;
    }

    public void SetIsUsed(bool value)
    {
        return;
    }


    // 배개가 kinetic이라 안던져짐, hold일때 키네틱 해제
}
