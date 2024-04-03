using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �ش� �������� ��� ���� Ȯ��
public class ItemPickUp : MonoBehaviour
{
    public enum ObjKind : short // enum inherit struct value, ( int, float ... )
    {
        notKey,
        under,
        whieDoor,
        battery,
        pillow,   
    }
    public Item item;
    protected bool isUsed = false;
    [SerializeField]
    private ObjKind objKind;
    protected bool isHolded = false;

    private void Update()
    {
        if (isUsed)
        {
            Destroy(this.gameObject);
        }
    }
    public bool GetIsUsed()
    {
        return isUsed;
    }
    public void SetIsUsed(bool value)
    { isUsed = value; }
    public bool GetIsHolded()
    {
        return isHolded;
    }
    public void SetIsHolded(bool value)
    { isHolded = value; }
    public ObjKind GetKeyKind()
    {
        return objKind;
    }

}
