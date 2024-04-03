using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : ItemPickUp
{
   private  const ObjKind objkind = ObjKind.pillow;

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

    }
    private void Start()
    {
        rb.useGravity = false;
    }
    private void Update()
    {
        if (GetIsHolded())
        {
            uicontroller.SetTextGUI((int)UiController.ObjectTags.pillow);
        }
            
        if (GetIsHolded() && Input.GetMouseButtonDown(0))
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
