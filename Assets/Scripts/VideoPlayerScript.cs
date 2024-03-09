using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoPlayerScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void EndReached(UnityEngine.Video.VideoPlayer vp) {
        SceneManager.LoadScene("BasicLevel");
    
    }
    void Start()
    {
        GameObject camera = GameObject.Find("Main Camera");
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.url = "Assets/Videos/tomato anxiety.mp4";

        // By default, VideoPlayers added to a camera will use the far plane.
        // Let's target the near plane instead.
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
        videoPlayer.waitForFirstFrame = true;
        videoPlayer.loopPointReached += EndReached;
        videoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {   
        
    }
}
