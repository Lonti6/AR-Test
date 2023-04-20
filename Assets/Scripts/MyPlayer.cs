using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using YoutubePlayer;

public class MyPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    async void Start()
    {
        Debug.Log("Loading video...");
        var videoPlayer = GetComponent<VideoPlayer>();
        await videoPlayer.PlayYoutubeVideoAsync("https://www.youtube.com/watch?v=IBcwhaYP6Uk");
    }
}
