using UnityEngine;
using UnityEngine.Video;

public class DisableVideoOnEnd : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject videoUI;

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        videoUI.SetActive(false);
    }
}