using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoStream : MonoBehaviour
{
    public VideoPlayer player;
    public VideoClip[] clips;

    private int clipIndex;

    // Start is called before the first frame update
    void Start()
    {
        player.loopPointReached += OnVideoEnd;
        PlayNextClip();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayNextClip()
    {
        if (clipIndex < clips.Length)
        {
            Debug.Log($"Playing video {clipIndex}");
            player.clip = clips[clipIndex++];
            player.Play();
        }
        else
        {
            Debug.Log($"End of playlist reached");
        }
    }

    void OnVideoEnd(VideoPlayer source)
    {
        PlayNextClip();
    }
}
