using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaggedObjects : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Player GUI")]
    protected static TextMeshProUGUI _text;

    [SerializeField]
    private GameManager gamemanager;

    protected bool _isRaycasted;
    private float fadeTime = 1.0f;
    protected Coroutine _coroutine;
    private void Awake()
    {
        _text = gamemanager.GetPlayerGUI();
    }
    public void SetIsRayCasted(bool value)
    {
        _isRaycasted = value;
    }
    public IEnumerator Fade(float start, float end)
    {
        Debug.Log("fade");
        float currentTime = 0;
        float percent = 0;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color color = _text.color;
            color.a = Mathf.Lerp(start, end, percent);
            _text.color = color;
            yield return null;
        }
    }
}
