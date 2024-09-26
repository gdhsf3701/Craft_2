using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class DiedScript : MonoBehaviour
{

    public bool _isClearChap1;
    [SerializeField] private PlayableDirector cutsceneOne;
    [SerializeField] private PlayableDirector cutsceneTwo;
    [SerializeField] private Teleporter teleporter;

    public void OnDied()
    {
        if (_isClearChap1)
        { 
            cutsceneTwo.Play();
        }
        else
        {
            cutsceneOne.Play();
        }


    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Chap2Die()
    {
        teleporter.Died();
    }
    public void Chat()
    {
        if (_isClearChap1)
        {

            ChatSystem.Instance.TypCoStart("금자월", "어째서.. 또..", 0.2f);
            StartCoroutine(wait());
            ChatSystem.Instance.TypCoStart("금자월", "이번엔.. 잘했다고 생각했는데..", 0.2f);
        }
        else
        {

        }
    }

    IEnumerator wait()
    {
        yield return new WaitUntil(() => ChatSystem.Instance.endText == true);
        yield return new WaitForSeconds(2);
    }
}
