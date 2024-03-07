using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    public GameObject uiImage; // 종이와 상호작용 시 표시할 UI 이미지

    // 종이와 상호작용 시 호출되는 메서드
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
            // UI 이미지를 활성화
            uiImage.SetActive(true);
        }
    }
}

