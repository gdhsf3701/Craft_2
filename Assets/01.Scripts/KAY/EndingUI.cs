using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using UnityEngine.UIElements.Experimental;

public class EndingUI : MonoBehaviour
{
    public VisualTreeAsset cutsceneTemplate;
    private VisualElement root;
    private Label text1, text2;
    private VisualElement credits;
    private float fadeDuration = 1; // 페이드 인/아웃 시간
    private float displayDuration = 3f; // 텍스트 표시 시간
    private float scrollSpeed = 50f; // 크레딧 스크롤 속도

    void Start()
    {
        // UIDocument의 루트 엘리먼트 가져오기
        root = GetComponent<UIDocument>().rootVisualElement;

        // 템플릿을 인스턴스화하고 루트에 추가
        var cutscene = cutsceneTemplate.Instantiate();
        root.Add(cutscene);

        // 텍스트와 크레딧 요소 가져오기
        text1 = root.Q<Label>("text1");
        text2 = root.Q<Label>("text2");
        credits = root.Q<VisualElement>("credits");

        // null 체크
        if (text1 == null)
        {
            Debug.LogError("text1 is null");
        }
        if (text2 == null)
        {
            Debug.LogError("text2 is null");
        }
        if (credits == null)
        {
            Debug.LogError("credits is null");
        }

        // 코루틴을 사용하여 페이드 인/아웃 애니메이션을 순차적으로 실행
        StartCoroutine(PlayCutscene());
    }


    IEnumerator PlayCutscene()
    {
        // 첫 번째 텍스트 페이드 인/아웃
        yield return StartCoroutine(FadeText(text1));
        // 두 번째 텍스트 페이드 인/아웃
        yield return StartCoroutine(FadeText(text2));
        // 엔딩 크레딧 페이드 인 후 스크롤 시작
        StartCoroutine(ShowCredits());
    }

    IEnumerator FadeText(Label text)
    {
        // 텍스트가 null인지 확인
        if (text == null)
        {
            Debug.LogError("Text is null");
            yield break; // 텍스트가 null일 경우 코루틴 종료
        }

        // 페이드 인
        text.style.opacity = 0;
        text.experimental.animation.Start(new StyleValues { opacity = 1 }, (int)fadeDuration);
        yield return new WaitForSeconds(fadeDuration + displayDuration);

        // 페이드 아웃
        text.experimental.animation.Start(new StyleValues { opacity = 0 }, (int)fadeDuration);
        yield return new WaitForSeconds(fadeDuration);
    }
    IEnumerator ShowCredits()
    {
        // 크레딧 페이드 인
        credits.style.opacity = 0;
        credits.experimental.animation.Start(new StyleValues { opacity = 1 }, (int)(fadeDuration));
        yield return new WaitForSeconds(fadeDuration);

        // 크레딧 스크롤
        credits.experimental.animation.Start(
            new StyleValues { top = -credits.resolvedStyle.height },
            (int)scrollSpeed
        );
    }
}
