using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Radio : MonoBehaviour
{
    [SerializeField]
    private ItemPickUp battery;

    public void GetHint()
    {
        if (!battery.GetIsHolded())

       if(battery.GetIsHolded() && ItemPickUp.ObjKind.battery == battery.GetKeyKind())
        {
            
        }
    }
}
