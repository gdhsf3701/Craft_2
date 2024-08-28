using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EasterEggSorry : MonoBehaviour
{
    static public int deathCount = 0;
    static string lastStage;
    [SerializeField] GameObject videoPlayer;
    VideoPlayer video;
    bool played = false;
    private void Awake()
    {
        video = GetComponent<VideoPlayer>();
        videoPlayer.SetActive(false);
        string nowScene = SceneManager.GetActiveScene().name;
        if (nowScene != "StartScene")
        {
            if(nowScene != lastStage)
            {
                deathCount = 0;
            }
        }
        lastStage = SceneManager.GetActiveScene().name;
    }
    private void Update()
    {
        if (deathCount == 50 && !played) 
        {
            played = true;
            videoPlayer.SetActive(true);
            video.Play();
            StartCoroutine(VideoWaitCoroutine(video));
        }
    }

    private IEnumerator VideoWaitCoroutine(VideoPlayer video)
    {
        yield return new WaitForSeconds((float)video.length);
        videoPlayer.SetActive(false);
    }
}
