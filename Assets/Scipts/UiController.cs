using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiController : MonoBehaviour
{
    [Header("message UI")]
    [SerializeField]
    private GameObject playerUI;
    [SerializeField]
    private TextMeshProUGUI playerUITextMeshPro;
    public List<GameObject> UiImage = new List<GameObject>();

    private void OnEnable()
    {
        playerUI.SetActive(false);
    }
    public void DisplayMessage(string message, bool isActive)
    {
        playerUI.SetActive(isActive);
        if (playerUI != null)
        {
            playerUITextMeshPro.text = message;
        }
    }
    public void UiDelete()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            for (int i = 0; i < UiImage.Count; i++)
            {
                if (UiImage[i].activeSelf)
                {
                    UiImage[i].SetActive(false);
                }
            }
        }
    }
}