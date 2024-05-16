using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    public GameObject uiImage; // ���̿� ��ȣ�ۿ� �� ǥ���� UI �̹���
    [SerializeField]
    private GameObject _player;

    // ���̿� ��ȣ�ۿ� �� ȣ��Ǵ� �޼���
    private void OnEnable()
    {
        uiImage.SetActive(false);
    }
    private void Update()
    {
        if (uiImage.activeSelf)
        {
            if(Vector3.Distance(_player.transform.position, this.transform.position) > 6) 
            {
                uiImage.SetActive(false);
            }
        }
    }
    public void Interact()
    {
        if (uiImage.activeSelf)
        {
            uiImage.SetActive(false);
        }
        else
        {
            // UI �̹����� Ȱ��ȭ
            uiImage.SetActive(true);
        }
    }
}

