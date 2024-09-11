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
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        video = GetComponent<VideoPlayer>();
        videoPlayer.SetActive(false);
        string nowScene = SceneManager.GetActiveScene().name;
        if (nowScene == "StartScene"|| nowScene != lastStage)
        {
            deathCount = 0;
        }
        lastStage = SceneManager.GetActiveScene().name;
    }
    private void Update()
    {
        if (deathCount == 50) 
        {
            deathCount = 0;
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
