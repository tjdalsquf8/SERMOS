using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class FadeEffect : MonoBehaviour
{
    private float fadeTime = 1.0f;
    private TextMeshPro text;
    private void Awake()
    {
        text = GetComponent<TextMeshPro>();
    }
    private void OnEnable()
    {
        this.enabled = false;
    }

    public IEnumerator Fade(float start, float end)
    {
        float currentTime = 0;
        float percent = 0;

        while(percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color color = text.color;
            color.a = Mathf.Lerp(start, end, percent);
            text.color = color;
            yield return null;
        }
    }
}
