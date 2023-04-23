using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Updater : MonoBehaviour
{
    public void FoundImage()
    {
        Debug.Log("found image");
    }
    public void PlayVideo()
    {
        var video = GameObject.FindGameObjectWithTag("VideoPlayer").GetComponent<VideoPlayer>();
        video.Play();
    }
    public void StopVideo()
    {
        var video = GameObject.FindGameObjectWithTag("VideoPlayer").GetComponent<VideoPlayer>();
        video.Stop();
    }



    public void NotFoundImage()
    {
        Debug.Log("not found image");
    }
}
