using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoOutDoor : Door
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
   /* public IEnumerator Fade(float start, float end)
    {
        float currentTime = 0;
        float percent = 0;
        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;
            Color color = image.color;
            color.a = Mathf.Lerp(start, end, percent);
            image.color = color;
            yield return null;
        }

    
}
   */