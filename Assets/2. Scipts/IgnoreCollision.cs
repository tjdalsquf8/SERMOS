using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    public GameObject objectToIgnore;

    void Start()
    {
        objectToIgnore = GameObject.FindGameObjectWithTag("Player");
        // �浹 ���� ����
        Physics.IgnoreCollision(GetComponent<Collider>(), objectToIgnore.GetComponent<Collider>(), true);
    }
}