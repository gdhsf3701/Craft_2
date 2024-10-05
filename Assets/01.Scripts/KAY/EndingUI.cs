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
    private float fadeDuration = 1; // ���̵� ��/�ƿ� �ð�
    private float displayDuration = 3f; // �ؽ�Ʈ ǥ�� �ð�
    private float scrollSpeed = 50f; // ũ���� ��ũ�� �ӵ�

    void Start()
    {
        // UIDocument�� ��Ʈ ������Ʈ ��������
        root = GetComponent<UIDocument>().rootVisualElement;

        // ���ø��� �ν��Ͻ�ȭ�ϰ� ��Ʈ�� �߰�
        var cutscene = cutsceneTemplate.Instantiate();
        root.Add(cutscene);

        // �ؽ�Ʈ�� ũ���� ��� ��������
        text1 = root.Q<Label>("text1");
        text2 = root.Q<Label>("text2");
        credits = root.Q<VisualElement>("credits");

        // null üũ
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

        // �ڷ�ƾ�� ����Ͽ� ���̵� ��/�ƿ� �ִϸ��̼��� ���������� ����
        StartCoroutine(PlayCutscene());
    }


    IEnumerator PlayCutscene()
    {
        // ù ��° �ؽ�Ʈ ���̵� ��/�ƿ�
        yield return StartCoroutine(FadeText(text1));
        // �� ��° �ؽ�Ʈ ���̵� ��/�ƿ�
        yield return StartCoroutine(FadeText(text2));
        // ���� ũ���� ���̵� �� �� ��ũ�� ����
        StartCoroutine(ShowCredits());
    }

    IEnumerator FadeText(Label text)
    {
        // �ؽ�Ʈ�� null���� Ȯ��
        if (text == null)
        {
            Debug.LogError("Text is null");
            yield break; // �ؽ�Ʈ�� null�� ��� �ڷ�ƾ ����
        }

        // ���̵� ��
        text.style.opacity = 0;
        text.experimental.animation.Start(new StyleValues { opacity = 1 }, (int)fadeDuration);
        yield return new WaitForSeconds(fadeDuration + displayDuration);

        // ���̵� �ƿ�
        text.experimental.animation.Start(new StyleValues { opacity = 0 }, (int)fadeDuration);
        yield return new WaitForSeconds(fadeDuration);
    }
    IEnumerator ShowCredits()
    {
        // ũ���� ���̵� ��
        credits.style.opacity = 0;
        credits.experimental.animation.Start(new StyleValues { opacity = 1 }, (int)(fadeDuration));
        yield return new WaitForSeconds(fadeDuration);

        // ũ���� ��ũ��
        credits.experimental.animation.Start(
            new StyleValues { top = -credits.resolvedStyle.height },
            (int)scrollSpeed
        );
    }
}
