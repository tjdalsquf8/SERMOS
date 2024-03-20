using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    public GameObject uiImage; // ���̿� ��ȣ�ۿ� �� ǥ���� UI �̹���

    // ���̿� ��ȣ�ۿ� �� ȣ��Ǵ� �޼���
    private void OnEnable()
    {
        uiImage.SetActive(false);
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

