using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    public GameObject objectToIgnore;

    void Start()
    {
        objectToIgnore = GameObject.FindGameObjectWithTag("Player");
        // 충돌 무시 설정
        Physics.IgnoreCollision(GetComponent<Collider>(), objectToIgnore.GetComponent<Collider>(), true);
    }
}