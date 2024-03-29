using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 해당 아이템의 사용 유무 확인
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
    private bool isUsed = false;
    [SerializeField]
    private ObjKind objKind;
    private bool isHolded = false;

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
