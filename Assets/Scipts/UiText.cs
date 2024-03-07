using System.Collections;

using UnityEngine;

using UnityEngine.UI;



public class QuizManager : MonoBehaviour

{

    // Start is called before the first frame update



    public Text resultText;

    public float waitTime;

    public GameObject canvas;



    public void ClickO()

    {

        resultText.text = "Good!";

        StartCoroutine(Delay());

    }

    public void ClickX()

    {

        resultText.text = "ddang!";

        StartCoroutine(Delay());

    }



    public void Finish()

    {

        canvas.SetActive(false);

    }



    IEnumerator Delay()

    {

        yield return new WaitForSeconds(waitTime);

        resultText.text = "";

    }

}