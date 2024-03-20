using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class UiController : MonoBehaviour
{

    public enum UiState
    {
        PlayerUi,
        SystemUi
    }
    private Coroutine fadeCoroutine;
    private string currentPlayerUitext;
    [Header("message UI")]
    [SerializeField]
    private GameObject playerUI;
    private TextMeshProUGUI playerUITextMeshPro;
    public List<GameObject> UiImage = new List<GameObject>();
    private float fadeTime = 1.0f;
    private TextMeshProUGUI text; // system message
    private TextMeshProUGUI SystemMessage; // system message
    private void Awake()
    {
        SystemMessage = GetComponent<TextMeshProUGUI>();
        text = SystemMessage;
        playerUITextMeshPro = playerUI.GetComponentInChildren<TextMeshProUGUI>();
    }
    
    /*public void DisplayMessage(string message, bool isActive)
    {
        playerUI.SetActive(isActive);
        if (playerUI != null)
        {
            playerUITextMeshPro.text = message;
        }
    }*/

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

    private IEnumerator Fade(float start, float end, string message, UiState state) // Fade out = Fade(1,0, "")
    {
        Debug.Log("run fade coroutine");
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
                // text.color의 알파 값이 end와 거의 동일한 경우 코루틴 중지
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
        // 켜짐 -> 유지 -> raycast false -> 꺼짐
        // yield return startcoroutine -> 유지 -> raycast false <? false인 자리에 start 넣으면 계속 실행됨, 
      

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
    }
}