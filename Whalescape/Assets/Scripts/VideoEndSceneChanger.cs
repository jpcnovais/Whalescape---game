using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEndSceneChanger : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    [SerializeField]
    public string nextscene;

    void Start()
    {

        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }


        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {

        SceneManager.LoadScene(nextscene);
    }

}
