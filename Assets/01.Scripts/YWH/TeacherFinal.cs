using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeacherFinal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Teacher());
    }

    IEnumerator Teacher()
    {
        FadeManager.instance.FadeIn(1);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneName.Stage2);
    }
}
