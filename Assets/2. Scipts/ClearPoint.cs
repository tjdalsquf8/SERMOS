using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ClearPoint : MonoBehaviour
{
    public Image Panel;
    float time = 0f;
    float F_time = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.SetGameClear(true);
        }
        StartCoroutine(FadeFlow());

        IEnumerator FadeFlow()
        {
            Panel.gameObject.SetActive(true);
            Color alpha = Panel.color;

            while (alpha.a < 1f)
            {
                time += Time.deltaTime / F_time;
                alpha.a = Mathf.Lerp(0, 1, time);
                Panel.color = alpha;
                yield return null;
            }
            yield return null;
            SceneManager.LoadScene("EndScene");
        }
    }
}
