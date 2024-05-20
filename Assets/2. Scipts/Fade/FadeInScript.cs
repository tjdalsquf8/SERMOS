using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FadeInScript : MonoBehaviour
{
    public Image Panel; // �г� �̹���
    float time = 0f; // ��� �ð��� �����ϴ� ����
    float F_time = 4.0f; // ���̵� �� ȿ���� �ɸ��� �� �ð�

    void Start()
    {
        Fade(); // ���� ���۵��ڸ��� ���̵� �� ȿ���� ����
    }

    public void Fade()
    {
        StartCoroutine(FadeInFlow()); // ���̵� �� �ڷ�ƾ�� ����
    }

    IEnumerator FadeInFlow()
    {
        Panel.gameObject.SetActive(true); // �г��� Ȱ��ȭ
        Color alpha = Panel.color; // �г��� ���� ������
        alpha.a = 1f; // �г��� ���� ���� 1�� ���� (������ ������)
        Panel.color = alpha; // �г� ���� ���� �� ����

        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time; // �ð� ���� ����
            alpha.a = Mathf.Lerp(1.5f, 0, time); // ���� ���� 1���� 0���� ���������� ����
            Panel.color = alpha; // �г� ���� ����� ���� �� ����
            yield return null; // ���� �����ӱ��� ���
        }

        alpha.a = 0f; // ���������� ���� ���� 0���� ����
        Panel.color = alpha; // �г� ���� ����
        Panel.gameObject.SetActive(false); // �г��� ��Ȱ��ȭ
        yield return null; // �ڷ�ƾ ����
    }
}
