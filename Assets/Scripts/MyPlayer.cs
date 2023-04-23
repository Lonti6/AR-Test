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

/*        videoPlayer.url = "https://rutube.ru/video/6ec3939b588fdd9134288804a0458c1a/";
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.Prepare();*/
        await videoPlayer.PlayYoutubeVideoAsync("https://www.youtube.com/watch?v=nADTdV8wsXQ");
    }
}
