using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    private void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void OnClickRestart()
    {
        SceneManager.LoadScene("GameScene");
    }    

    public void OnClickReturnMain()
    {
        SceneManager.LoadScene("MainScene");

    }
}
