using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 해당 아이템의 사용 유무 확인
public class ItemPickUp : MonoBehaviour
{
    public enum KeyKind : short // enum inherit struct value, ( int, float ... )
    {
        under,
        whieDoor,
    }
    public Item item;
    private bool isUsed = false;
    [SerializeField]
    private KeyKind keyKind;
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
    public KeyKind GetKeyKind()
    {
        return keyKind;
    }

}
