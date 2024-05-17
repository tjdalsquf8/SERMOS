//Main씬에서 게임플레이씬으로 이동
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    public GameObject optionCanvas;

    public void OnClickGameStart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnclickOption()
    {
        if(optionCanvas!=null)
        {
            optionCanvas.SetActive(true);
        }
    }

    public void OnclickBack()
    {
        if(optionCanvas!=null)
        {
            optionCanvas.SetActive(false);
        }
    }
}
