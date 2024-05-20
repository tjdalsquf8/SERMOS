using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FadeInScript : MonoBehaviour
{
    public Image Panel; // 패널 이미지
    float time = 0f; // 경과 시간을 저장하는 변수
    float F_time = 4.0f; // 페이드 인 효과가 걸리는 총 시간

    void Start()
    {
        Fade(); // 씬이 시작되자마자 페이드 인 효과를 시작
    }

    public void Fade()
    {
        StartCoroutine(FadeInFlow()); // 페이드 인 코루틴을 시작
    }

    IEnumerator FadeInFlow()
    {
        Panel.gameObject.SetActive(true); // 패널을 활성화
        Color alpha = Panel.color; // 패널의 색을 가져옴
        alpha.a = 1f; // 패널의 알파 값을 1로 설정 (완전히 불투명)
        Panel.color = alpha; // 패널 색에 알파 값 적용

        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time; // 시간 값을 증가
            alpha.a = Mathf.Lerp(1.5f, 0, time); // 알파 값을 1에서 0으로 점진적으로 변경
            Panel.color = alpha; // 패널 색에 변경된 알파 값 적용
            yield return null; // 다음 프레임까지 대기
        }

        alpha.a = 0f; // 마지막으로 알파 값을 0으로 설정
        Panel.color = alpha; // 패널 색에 적용
        Panel.gameObject.SetActive(false); // 패널을 비활성화
        yield return null; // 코루틴 종료
    }
}
