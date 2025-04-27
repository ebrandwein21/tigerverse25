using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(Renderer))]
public class ScreenVideoController : MonoBehaviour
{
    public string videoFileName = "sample_960x400_ocean_with_audio.mp4";
    public RenderTexture videoRT;    // assign in Inspector
    private VideoPlayer vp;

    void Awake() {
        vp = gameObject.AddComponent<VideoPlayer>();

        // 1. URL with file:///
        string path = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
        vp.url = "file:///" + path;

        // 2. Render into RT
        vp.renderMode    = VideoRenderMode.RenderTexture;
        vp.targetTexture = videoRT;

        // 3. Don’t auto-play
        vp.playOnAwake = false;
        vp.isLooping   = true;

        // 4. Prepare then play
        vp.prepareCompleted += OnPrepared;
        vp.errorReceived    += (p, msg) => Debug.LogError("VideoPlayer Error: " + msg);
        vp.Prepare();  // starts decoding first frames
    }

    void OnPrepared(VideoPlayer p) {
        // 5. Assign RT to material (if not done in Editor)
        GetComponent<Renderer>().material.mainTexture = videoRT;
        p.Play();  // frames available immediately :contentReference[oaicite:9]{index=9}
    }
}
