using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;

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
        pillow = 9,
    }
    [Header("Player UI List")]
    [SerializeField]
    private TextMeshProUGUI[] playerUI;

    [Header("Radio playback not possible, battery required.")]
    [SerializeField]
    private TextMeshProUGUI textGUI;

    [Header("F Image")]
    [SerializeField]
    private Image F;
    [Header("Mouse Button 0")]
    [SerializeField]
    private Image mouseButton_0;


    //public List<GameObject> UiImage = new List<GameObject>();
    private Image setImage;

    private int playerUISize;
    private int beforeUiIdx = 0;
    private float fadeTime = 1.0f;
    private void Awake()
    {
        playerUISize = playerUI.Length;
        setImage = F;
    }
    private void OnEnable()
    {
        for (int i = 0; i < playerUISize; i++)
        {
            playerUI[i].enabled  = false;
        }
        setImage.enabled = false;
    }
   /* public void UiDelete()
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
    }*/

    public void SetTextGUI(int value)
    {
        if (value == (int)ObjectTags.pillow)
        {
            if(F.enabled)F.enabled = false;
            setImage = mouseButton_0;
        }
        else
        {
            if(mouseButton_0.enabled) mouseButton_0.enabled = false;
            setImage = F;
        }
        // 2. 다를 경우 켜져 있는 ui를 끄고 value에 해당하는 UI를 킴
        // 3. raycast가 false 거나 Untagged 일경우
        // value = -1;
        // value = - 1 일경우 이전 idx와 같아 두번째 if 실행 x
        
        if(value < 0)
        {
            beforeUiIdx = value;
            for (int i = 0; i < playerUISize; i++)
            {
                if (playerUI[i].enabled)
                {
                    setImage.enabled = false;
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
                setImage.enabled = false;
                playerUI[beforeUiIdx].enabled = false;
            }
            beforeUiIdx = value;
            setImage.enabled = true; 
            playerUI[value].enabled = true;
            return;
        }
    } // value가 달라 겹쳐 보임

    public void SetThrowUI()
    {
        if(F.enabled) F.enabled = false;

    }

    // if dont have battery
   public void RadioPlaybackNoyPossible()
    {
        StartCoroutine(Fade(0, 1));
    }

    public IEnumerator Fade(float start, float end)
    {
        float currentTime = 0;
        float percent = 0;
        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;
         Color color = textGUI.color;
            color.a = Mathf.Lerp(start, end, percent);
            textGUI.color = color; 
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        currentTime = 0;
        percent = 0;
        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;
               Color color = textGUI.color;
            color.a = Mathf.Lerp(end, start, percent);
            textGUI.color = color;
            yield return null;
        }

    }

    
    
}