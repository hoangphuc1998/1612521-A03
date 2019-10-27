using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoPlay : MonoBehaviour
{
    VideoPlayer video;

    void Start()
    {
        video = GetComponent<VideoPlayer>();
        video.loopPointReached += CheckOver;
    }

    void Update()
    {
    }

    void CheckOver(VideoPlayer v)
    {
        Destroy(gameObject);
    }
}
