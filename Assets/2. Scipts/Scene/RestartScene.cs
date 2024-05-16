using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    public void OnClickRestart()
    {
        SceneManager.LoadScene("GameScene");
    }    

    public void OnClickReturnMain()
    {
        SceneManager.LoadScene("MainScene");

    }
}
