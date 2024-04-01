using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiController : MonoBehaviour
{

    public enum ObjectTags
    { 
        door = 0,
        concretedoor = 0,
        griddoor = 0,
        box = 2, // message box
        table = 4, // message drawer
        item = 6, // message pick Up
        paper = 7,
        radio = 8,
    }
    [Header("Player UI List")]
    [SerializeField]
    private TextMeshProUGUI[] playerUI;
    private int playerUISize;


    public List<GameObject> UiImage = new List<GameObject>();
    private int beforeUiIdx = 0;

    [Header("F Image")]
    [SerializeField]
    private Image F;
    private void Awake()
    {
        playerUISize = playerUI.Length;
    }
    private void OnEnable()
    {
        for (int i = 0; i < playerUISize; i++)
        {
            playerUI[i].enabled  = false;
        }
        F.enabled = false;
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

    public void SetTextGUI(int value)
    {

        // 1. value�� ���� �����ִ� value�� �ش��ϴ� UI�� ���� ��� return
        // 2. �ٸ� ��� ���� �ִ� ui�� ���� value�� �ش��ϴ� UI�� Ŵ
        // 3. raycast�� false �ų� Untagged �ϰ��
        // value = -1;
        // value = - 1 �ϰ�� ���� idx�� ���� �ι�° if ���� x
        if(value < 0)
        {
            beforeUiIdx = value;
            for (int i = 0; i < playerUISize; i++)
            {
                if (playerUI[i].enabled)
                {
                    F.enabled = false;
                    playerUI[i].enabled = false;
                    break;
                }
            }
            return;
        }
        if (!playerUI[value].enabled && beforeUiIdx != value)
        {
            if (beforeUiIdx >= 0)
            {
                F.enabled = false;
                playerUI[beforeUiIdx].enabled = false;
            }
            beforeUiIdx = value;
            F.enabled = true;
            playerUI[value].enabled = true;
            return;
        }
    } // value�� �޶� ���� ����

    #region FadeInout Code Dont Use
   /* private IEnumerator Fade(float start, float end, string message, UiState state) // Fade out = Fade(1,0, "")
    {
        float currentTime = 0;
        float percent = 0;
        if (state == UiState.PlayerUi)
        {
            text = playerUITextMeshPro;
        }
        else if (state == UiState.SystemUi)
        {
            text = SystemMessage;
        }
        text.text = message;
        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color color = text.color;
            color.a = Mathf.Lerp(start, end, percent);
            text.color = color;
            if (Mathf.Approximately(color.a, end))
            {
                // text.color�� ���� ���� end�� ���� ������ ��� �ڷ�ƾ ����
                break;
            }
            yield return null;
        }
    }
    public void FadeInOut(string message, UiState state, bool isCasted = false)
    {
        if (fadeCoroutine != null)
        {
            return;
        }
        // ���� -> ���� -> raycast false -> ����
        // yield return startcoroutine -> ���� -> raycast false <? false�� �ڸ��� start ������ ��� �����, 
      

        if (state == UiState.SystemUi)
        {
            StartCoroutine(MovePosY());
            text.transform.position = new Vector3(text.transform.position.x, text.transform.position.y - 10, text.transform.position.z);
        }
    }
    public IEnumerator MovePosY()
    {
        float currentValue = 0;
        float percent = 0;
        while (percent < 1)
        {
            currentValue += Time.deltaTime;
            percent = currentValue / 1;

            Vector3 newPosition = new Vector3(text.transform.position.x, Mathf.Lerp(currentValue, 10, percent), text.transform.position.z);
            text.transform.position = newPosition;

            yield return null;
        }
    }
    public void SetFadeCoroutineNull()
    {
        if (fadeCoroutine == null) return;
        fadeCoroutine = null;
    }
    public string GetCurrentPlayerUiText()
    {
        return currentPlayerUitext;
    }
    public void SetCurrentPlayerUiText(string message)
    {
        currentPlayerUitext = message;
    }*/
    #endregion
}