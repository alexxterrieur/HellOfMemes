using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoSwitch : MonoBehaviour
{
    [SerializeField] List<VideoClip> backgroundVideos;
    public VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    public void SwitchBackground()
    {
        VideoClip videoToPlay = backgroundVideos[Random.Range(0, backgroundVideos.Count)];
        videoPlayer.clip = videoToPlay;
    }
}
