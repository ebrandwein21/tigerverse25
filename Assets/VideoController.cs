using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoStream : MonoBehaviour
{
    public VideoPlayer player;
    public VideoClip[] clips;
    public int clipNum=0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Test"); 
        player.clip = clips[clipNum];
        player.Play();
        player.loopPointReached += OnVideoEnd;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnVideoEnd(VideoPlayer source)
    {
        if(clipNum<clips.Length-1)
        {
        clipNum++;
        player.Stop();
        player.clip = clips[clipNum];
        player.Play();
        }
        else
        {
            Debug.Log("End of video stream");
        }
    }
}