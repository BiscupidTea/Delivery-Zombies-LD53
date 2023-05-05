using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ChangeVideoSource : MonoBehaviour
{
    public VideoPlayer player;
    public string videoUrl;

    private void Start()
    {
        player = GetComponent<VideoPlayer>();
#if UNITY_WEBGL
        player.source = VideoSource.Url;
        player.url = videoUrl;
        player.EnableAudioTrack(0, true);
        player.Prepare();
#else
        player.source = VideoSource.VideoClip;
        player.clip = player.clip;
#endif
    }
}
