using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(Renderer))]               // Or RawImage for UI
public class ScreenScript : MonoBehaviour
{
    public string videoURL ="C:/Users/patri/ScreenStream/Assets/VRTemplateAssets/Videos/sample_960x400_ocean_with_audio.mp4"  ;                         // e.g. "http://localhost:8000/my.mp4"
    public RenderTexture renderTexture;             // Assign if using RenderTexture mode

    private VideoPlayer videoPlayer;
    private AudioSource audioSource;

    void Awake()
    {
        // 1. Ensure VideoPlayer exists
        videoPlayer = gameObject.GetComponent<VideoPlayer>()
                      ?? gameObject.AddComponent<VideoPlayer>();  // :contentReference[oaicite:8]{index=8}

        // 2. Configure playback
        videoPlayer.playOnAwake = false;                      // :contentReference[oaicite:9]{index=9}
        videoPlayer.source      = VideoSource.Url;
        videoPlayer.url         = videoURL;
        videoPlayer.renderMode  = VideoRenderMode.RenderTexture;  // :contentReference[oaicite:10]{index=10}
        videoPlayer.targetTexture = renderTexture;

        // 3. Audio setup
        audioSource = gameObject.AddComponent<AudioSource>();    // :contentReference[oaicite:11]{index=11}
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.SetTargetAudioSource(0, audioSource);

        // 4. Prepare events
        videoPlayer.prepareCompleted += OnPrepared;              // :contentReference[oaicite:12]{index=12}
        videoPlayer.errorReceived    += OnError;                 // :contentReference[oaicite:13]{index=13}

        // 5. Begin loading first frame
        videoPlayer.Prepare();                                   // :contentReference[oaicite:14]{index=14}
    }

    private void OnPrepared(VideoPlayer vp)
    {
        // Auto-play when ready; remove if you want manual Play control
        vp.Play();                                               // :contentReference[oaicite:15]{index=15}
    }

    private void OnError(VideoPlayer vp, string msg)
    {
        Debug.LogError($"VideoPlayer error: {msg}");
    }

    // Public controls for UI buttons or other scripts
    public void PlayVideo()
    {
        if (!videoPlayer.isPlaying)
            videoPlayer.Play();                                 // :contentReference[oaicite:16]{index=16}
    }

    public void PauseVideo()
    {
        if (videoPlayer.isPlaying)
            videoPlayer.Pause();                                // :contentReference[oaicite:17]{index=17}
    }

    public void StopVideo()
    {
        videoPlayer.Stop();                                     // :contentReference[oaicite:18]{index=18}
    }
}
