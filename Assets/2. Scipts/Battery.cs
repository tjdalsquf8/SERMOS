using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Battery : ItemPickUp
{
    [Header("if used, this obj pos")]
    [SerializeField]
    private Transform Usedpos;

    [Header("Radio")]
    [SerializeField]
    private Radio radio;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isUsed)
        {
            this.transform.SetParent(radio.transform);
            this.transform.SetPositionAndRotation(
                new Vector3(Usedpos.position.x
                , Usedpos.position.y
                , Usedpos.position.z)
                , new Quaternion(-90, Quaternion.identity.y, Quaternion.identity.z, 0 ));
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.SetIsHolded(false);
            Radio.batteryCount++;
            UiController.Instance.ShowCountBatteryUI();
            isUsed = false;
        }
    }  
}
