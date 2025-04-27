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
        Debug.Log($"Playing video {clipIndex}");
        player.clip = clips[clipIndex++];
        player.Play();
        clipIndex %= clips.Length;
    }

    void OnVideoEnd(VideoPlayer source)
    {
        PlayNextClip();
    }
}
