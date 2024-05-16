using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Item", menuName = "New Item/item")]
public class Item : ScriptableObject // 오브젝트에 컴포넌트로서 붙일 수 없음
    // 이벤트는 OnEnable, OnDisable, OnDestroy만 받을 수 있다.
    // 스크립트는 아닌 애셋이다. 어떤 고유한 파일.
{
   public enum ItemType
    {
        Equipment,
        Used,
        Ingredient,
        ETC,
    }
    public string _itemName; // 아이템 이르ㅁ
    public ItemType itemType; // 아이템 유혀ㅇ
    public Sprite itemImage;
    public GameObject itemPrefab; // 아이템 생ㅅㅓㅇ시 프리팹ㅇㅡㄹㅗ 찍어내ㅁㅁ

    // Image는 Canvas 위에서만 이미지를 띄움,
    // SPrite Canvas 와 상관없이 월드 어디서든 이미지를 띄울 수 있음
}
